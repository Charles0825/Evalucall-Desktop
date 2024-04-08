using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evalucall_Desktop
{
    public partial class EvalucallRecording : Form
    {
        RecorderER _recorder;
        HistoryER _history;
        SettingsER _settings;


        private bool isDragging = false;
        private int xOffset, yOffset;
        public EvalucallRecording()
        {
            InitializeComponent();
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

        private void recorder_Click(object sender, EventArgs e)
        {
            if(_recorder == null)
            {
                _recorder = new RecorderER();
                _recorder.FormClosed += Recorder_FormClosed;
                _recorder.MdiParent = this;
                _recorder.Dock = DockStyle.Fill;
                _recorder.Show();
            }
            else
            {
                _recorder.Activate();
            }

        }

        private void Recorder_FormClosed(object sender, FormClosedEventArgs e)
        {
            _recorder = null;
        }

        private void logout_Click(object sender, EventArgs e)
        {
            Evalucall evalucall = new Evalucall();
            evalucall.Show();
            this.Close();
        }

        private void history_Click(object sender, EventArgs e)
        {
            if (_history == null)
            {
                _history = new HistoryER();
                _history.FormClosed += History_FormClosed;
                _history.MdiParent = this;
                _history.Dock = DockStyle.Fill;
                _history.Show();
            }
            else
            {
                _history.Activate();
            }
        }

        private void History_FormClosed(object sender, FormClosedEventArgs e)
        {
            _history = null;
        }

        private void settings_Click(object sender, EventArgs e)
        {
            if (_settings == null)
            {
                _settings = new SettingsER();
                _settings.FormClosed += Settings_FormClosed;
                _settings.MdiParent = this;
                _settings.Dock = DockStyle.Fill;
                _settings.Show();
            }
            else
            {
                _settings.Activate();
            }
        }

        private void Settings_FormClosed(object sender, FormClosedEventArgs e)
        {
            _settings = null;
        }

        private void EvalucallRecording_Load(object sender, EventArgs e)
        {
            this.recorder_Click(sender,e);
        }     

        private void topbar_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }
    }
}
