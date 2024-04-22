using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;

namespace Evalucall_Desktop
{
    public partial class EvalucallRecording : Form
    {
        private bool isDragging = false;
        private int xOffset, yOffset;
        private bool isRecording = false;
        private TimeSpan duration = TimeSpan.Zero;
        private Timer timer;
        private WaveInEvent waveSource;
        private WaveFileWriter waveFile;
        private int userId;
        private string filePath;

        public EvalucallRecording(int userId)
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            this.userId = userId;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void minimizeBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void topbar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                xOffset = e.X;
                yOffset = e.Y;
            }
        }

        private void topbar_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                int x = MousePosition.X - xOffset;
                int y = MousePosition.Y - yOffset;
                this.Location = new System.Drawing.Point(x, y);
            }
        }

        private void topbar_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            duration = duration.Add(TimeSpan.FromSeconds(1));
            RecordDuration.Text = duration.ToString(@"hh\:mm\:ss");
        }

        private async void RecordBtn_Click(object sender, EventArgs e)
        {
            if (!isRecording)
            {
                bool isApiOnline = await CheckApiOnline();
                if (isApiOnline)
                {
                    StartRecording();
                }
                else
                {
                    //MessageBox.Show("API is not online. Please try again later.");
                    RecordNotification.Text = "API is not online. Please try again later.";
                }
            }
            else
            {
                StopRecording();
            }
        }

        private async Task<bool> CheckApiOnline()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync("http://127.0.0.1:5000/api_status");
                    return response.IsSuccessStatusCode;
                }
            }
            catch
            {
                return false;
            }
        }

        private void StartRecording()
        {
            duration = TimeSpan.Zero;
            RecordDuration.Text = duration.ToString(@"hh\:mm\:ss");

            isRecording = true;
            timer.Start();
            RecordNotification.Text = "Recording...";

            waveSource = new WaveInEvent();
            waveSource.WaveFormat = new WaveFormat(44100, 1);
            waveSource.DataAvailable += WaveSource_DataAvailable;

            string userDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "EvalucallDesktop");
            Directory.CreateDirectory(userDirectory);

            string outputDirectory = Path.Combine(userDirectory, "Recordings");
            Directory.CreateDirectory(outputDirectory);

            // Append userId to the file name
            string fileName = $"{DateTime.Now:yyyyMMdd_HHmmss}_{userId}.wav";
            filePath = Path.Combine(outputDirectory, fileName);

            waveFile = new WaveFileWriter(filePath, waveSource.WaveFormat);
            waveSource.StartRecording();
        }


        private async Task UploadAudioFile(string filePath, string id, string name, string email, TimeSpan duration, DateTime dateTime)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                using (var content = new MultipartFormDataContent())
                using (var fileStream = new FileStream(filePath, FileMode.Open))
                {
                    // Add the audio file to the multipart form data
                    content.Add(new StreamContent(fileStream), "audio", Path.GetFileName(filePath));

                    // Add additional fields to the multipart form data
                    content.Add(new StringContent(id), "id");
                    content.Add(new StringContent(name), "name");
                    content.Add(new StringContent(email), "email");

                    // Add duration to the multipart form data
                    content.Add(new StringContent(duration.ToString()), "duration");

                    // Add date and time to the multipart form data
                    content.Add(new StringContent(dateTime.ToString()), "datetime");

                    // Send the POST request
                    HttpResponseMessage response = await client.PostAsync("http://127.0.0.1:5000/process_audio", content);

                    if (response.IsSuccessStatusCode)
                    {
                        RecordNotification.Text = "File uploaded successfully.";
                    }
                    else
                    {
                        RecordNotification.Text = "File upload failed. Server returned " + response.StatusCode;
                    }
                }
            }
            catch (Exception ex)
            {
                RecordNotification.Text = "Error: " + ex.Message;
            }
        }



        // Modify your StopRecording method to call the upload method after stopping recording
        private async void StopRecording()
        {
            isRecording = false;
            timer.Stop();
            RecordNotification.Text = "";
            waveSource.StopRecording();
            waveSource.Dispose();
            waveFile.Close();
            waveFile.Dispose();
            Console.WriteLine(filePath);
            await UploadAudioFile(filePath, "1", "Charles Lim", "Charles@gmail.com", duration, DateTime.Now);
            
        }

        private void EvalucallRecording_Load(object sender, EventArgs e)
        {

        }

        private void WaveSource_DataAvailable(object sender, WaveInEventArgs e)
        {
            waveFile.Write(e.Buffer, 0, e.BytesRecorded);
        }
    }
}
