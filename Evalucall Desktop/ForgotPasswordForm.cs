using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Evalucall_Desktop
{
    public partial class ForgotPasswordForm : Form
    {
        private const string EmailPlaceholder = "Enter your email";

        public ForgotPasswordForm()
        {
            InitializeComponent();
            InitializeLoginForm();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        // Email Placeholder

        private void InitializeLoginForm()
        {
            txtEmail.Text = EmailPlaceholder;
            txtEmail.ForeColor = SystemColors.GrayText;
            txtEmail.GotFocus += TxtEmail_GotFocus;
            txtEmail.Leave += TxtEmail_Leave;
        }

        private void TxtEmail_GotFocus(object sender, EventArgs e)
        {
            if (txtEmail.Text == EmailPlaceholder)
            {
                txtEmail.Text = "";
                txtEmail.ForeColor = SystemColors.ControlText;
            }
        }

        private void TxtEmail_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                txtEmail.Text = EmailPlaceholder;
                txtEmail.ForeColor = SystemColors.GrayText;
            }
        }

        // Validate Email
        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                string DomainMapper(Match match)
                {
                    var idn = new System.Globalization.IdnMapping();

                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        private void emailmeBtn_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();

            if (email == EmailPlaceholder)
            {
                DisplayNotification("Email field cannot be empty.", NotificationType.Error);
                return;
            }

            if (!IsValidEmail(email))
            {
                DisplayNotification("Please enter a valid email address.", NotificationType.Error);
                return;
            }

            DisplayNotification("Email sent!", NotificationType.Success);

            //txtEmail.Text = EmailPlaceholder;
            //txtEmail.ForeColor = SystemColors.GrayText;
            //txtMessage.Text = "";

            ForgotPasswordForm2 forgotPasswordForm2 = new ForgotPasswordForm2(email);
            forgotPasswordForm2.StartPosition = FormStartPosition.CenterParent;
            forgotPasswordForm2.ShowDialog(this);

            this.Close();

        }

        private void DisplayNotification(string message, NotificationType type)
        {
            txtMessage.Text = message;
            txtMessage.TextAlign = ContentAlignment.MiddleCenter;

            switch (type)
            {
                case NotificationType.Error:
                    txtMessage.ForeColor = Color.Red;
                    break;
                case NotificationType.Success:
                    txtMessage.ForeColor = Color.Green;
                    break;
                default:
                    txtMessage.ForeColor = SystemColors.ControlText;
                    break;
            }
        }
        public enum NotificationType
        {
            Error,
            Success
        }

    }
}
