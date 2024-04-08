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
    public partial class RecorderER : Form
    {
        public RecorderER()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar.Width += 5; 
            int progressPercentage = (int)((float)progressBar.Width / 500 * 100);
            progPercentage.Text = $"{progressPercentage}%";

            if (progressBar.Width >= 500)
            {
                timer1.Stop();
                progPercentage.Hide();
                uploadingrecentcalls.Hide();
                progressBar.Hide();
                progBack.Hide();
            }
        }
    }
}
