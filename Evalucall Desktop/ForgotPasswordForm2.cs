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
    public partial class ForgotPasswordForm2 : Form
    {
        public string Data { get; set; }
        public ForgotPasswordForm2( string data)
        {
            InitializeComponent();
            Data = data;
            linkLabel1.Text = $"A password reset email has been sent to {Data}, If it exists in our system. Resend or change email";
            linkLabel1.Links.Add(linkLabel1.Text.Length-22, linkLabel1.Text.Length, "ResendChangeEmail");
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (e.Link.LinkData as string == "ResendChangeEmail")
            {

                ForgotPasswordForm forgotPasswordForm = new ForgotPasswordForm();
                forgotPasswordForm.ShowDialog(this);

                this.Close();
            }
        }

        private void TxtBackLogin_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
