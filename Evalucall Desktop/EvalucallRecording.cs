using System;
using System.IO;
using System.Linq;
using System.Net.Http;
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
        private string name;
        private string email;
        private string filePath;
        private NotificationManager notificationManager;
        private string processAudioUrl;
        private string apiStatusUrl;

        public EvalucallRecording(int userId, string name, string email)
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            this.userId = userId;
            this.name = name;
            this.email = email;
            notificationManager = new NotificationManager(RecordNotification);

            var appSettings = new AppSettings();
            processAudioUrl = appSettings.ProcessAudioURL();
            apiStatusUrl = appSettings.ApiStatusURL();
            Console.WriteLine("Connection string: " + processAudioUrl);
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
            try
            {
                // Disable the RecordBtn to prevent spamming
                RecordBtn.Enabled = false;

                if (!isRecording)
                {
                    notificationManager.DisplayNotification("Checking server..", NotificationManager.NType.Default);
                    bool isApiOnline = await CheckApiOnline();
                    if (isApiOnline)
                    {
                        StartRecording();
                    }
                    else
                    {
                        notificationManager.DisplayNotification("API is not online. Please try again later.", NotificationManager.NType.Error);
                    }
                }
                else
                {
                    StopRecording();
                }
            }
            catch (Exception ex)
            {
                notificationManager.DisplayNotification("An error occurred: " + ex.Message, NotificationManager.NType.Error);
            }
            finally
            {
                // Enable the RecordBtn after operation completes
                RecordBtn.Enabled = true;
            }
        }


        private async Task<bool> CheckApiOnline()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(apiStatusUrl);
                    return response.IsSuccessStatusCode;
                }
            }
            catch (Exception ex)
            {
                notificationManager.DisplayNotification("An error occurred while checking API status: " + ex.Message, NotificationManager.NType.Error);
                return false;
            }
        }

        private void StartRecording()
        {
            duration = TimeSpan.Zero;
            RecordDuration.Text = duration.ToString(@"hh\:mm\:ss");

            isRecording = true;
            timer.Start();
            RecordNotification.Text = "Recording . . .";

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


        private async Task UploadAudioFile(string filePath, int id, string name, string email, TimeSpan duration, DateTime dateTime)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                using (var content = new MultipartFormDataContent())
                using (var fileStream = new FileStream(filePath, FileMode.Open))
                {
                    content.Add(new StreamContent(fileStream), "audio", Path.GetFileName(filePath));
                    content.Add(new StringContent(id.ToString()), "id");
                    content.Add(new StringContent(name), "name");
                    content.Add(new StringContent(email), "email");
                    content.Add(new StringContent(duration.ToString()), "duration");
                    content.Add(new StringContent(dateTime.ToString()), "datetime");

                    HttpResponseMessage response = await client.PostAsync(processAudioUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        notificationManager.DisplayNotification("File uploaded successfully.", NotificationManager.NType.Success);

                    }
                    else
                    {
                        notificationManager.DisplayNotification("File upload failed. Server returned " + response.StatusCode, NotificationManager.NType.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                notificationManager.DisplayNotification("Error: " + ex.Message, NotificationManager.NType.Error);

            }
        }

        private async void StopRecording()
        {
            try
            {
                isRecording = false;
                timer.Stop();
                RecordNotification.Text = "";
                waveSource.StopRecording();
                waveSource.Dispose();
                waveFile.Close();
                waveFile.Dispose();
                Console.WriteLine(filePath);

                if (GetTotalRecordingsCount() >= 20)
                {
                    DeleteOldestRecording();
                }

                await UploadAudioFile(filePath, userId, name, email, duration, DateTime.Now);
            }
            catch (Exception ex)
            {
                notificationManager.DisplayNotification("An error occurred while stopping recording: " + ex.Message, NotificationManager.NType.Error);
            }
        }

        private int GetTotalRecordingsCount()
        {
            try
            {
                string userDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "EvalucallDesktop");
                string outputDirectory = Path.Combine(userDirectory, "Recordings");

                string[] files = Directory.GetFiles(outputDirectory);

                return files.Length;
            }
            catch (Exception ex)
            {
                notificationManager.DisplayNotification("An error occurred while getting total recordings count: " + ex.Message, NotificationManager.NType.Error);
                return 0;
            }
        }

        private void DeleteOldestRecording()
        {
            try
            {
                string userDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "EvalucallDesktop");
                string outputDirectory = Path.Combine(userDirectory, "Recordings");

                string[] files = Directory.GetFiles(outputDirectory);

                string oldestRecording = files.OrderBy(f => new FileInfo(f).CreationTime).FirstOrDefault();

                if (!string.IsNullOrEmpty(oldestRecording))
                {
                    File.Delete(oldestRecording);
                }
            }
            catch (Exception ex)
            {
                notificationManager.DisplayNotification("An error occurred while deleting the oldest recording: " + ex.Message, NotificationManager.NType.Error);
            }
        }

        private void WaveSource_DataAvailable(object sender, WaveInEventArgs e)
        {
            waveFile.Write(e.Buffer, 0, e.BytesRecorded);
        }
    }
}
