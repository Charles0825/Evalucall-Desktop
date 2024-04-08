using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing;

namespace Evalucall_Desktop
{
    public partial class Evalucall : Form
    {
        private bool isDragging = false;
        private int xOffset, yOffset;
        private const string EmailPlaceholder = "Enter your email";
        private const string PasswordPlaceholder = "Enter your password";

        public Evalucall()
        {
            InitializeComponent();
            InitializeLoginForm();
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



        // START OF LOGIN FUNCTIONS
        private void loginBtn_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;

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

            if (password == PasswordPlaceholder)
            {
                DisplayNotification("Password field cannot be empty.", NotificationType.Error);
                return;
            }

            if (password.Length < 6) 
            {
                DisplayNotification("Password must be at least 6 characters long.", NotificationType.Error);
                return;
            }

            string validEmail = "sample@gmail.com";
            string validPassword = "aadmin";

            if (email == validEmail && password == validPassword)
            {
                DisplayNotification("Login successful!", NotificationType.Success);
  
            }
            else
            {
                DisplayNotification("Invalid email or password.", NotificationType.Error);
            }
        }

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

        private void InitializeLoginForm()
        {
            txtEmail.Text = EmailPlaceholder;
            txtEmail.ForeColor = SystemColors.GrayText;
            txtPassword.Text = PasswordPlaceholder;
            txtPassword.ForeColor = SystemColors.GrayText;

            txtEmail.GotFocus += TxtEmail_GotFocus;
            txtPassword.GotFocus += TxtPassword_GotFocus;
            txtEmail.Leave += TxtEmail_Leave;
            txtPassword.Leave += TxtPassword_Leave;
        }

        private void TxtEmail_GotFocus(object sender, EventArgs e)
        {
            if (txtEmail.Text == EmailPlaceholder)
            {
                txtEmail.Text = "";
                txtEmail.ForeColor = SystemColors.ControlText;
            }
        }

        private void TxtPassword_GotFocus(object sender, EventArgs e)
        {
            if (txtPassword.Text == PasswordPlaceholder)
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = SystemColors.ControlText;
                txtPassword.PasswordChar = '*';
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

        private void TxtPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                txtPassword.Text = PasswordPlaceholder;
                txtPassword.ForeColor = SystemColors.GrayText;
                txtPassword.PasswordChar = '\0';
            }
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

        private void forgotBtn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Opacity = 0.9;
            ForgotPasswordForm forgotPasswordForm = new ForgotPasswordForm();
            forgotPasswordForm.StartPosition = FormStartPosition.CenterParent;
            forgotPasswordForm.ShowDialog(this);
            this.Opacity = 1.0;
        }

        public enum NotificationType
        {
            Error,
            Success
        }

        // DisplayNotification("Error: Something went wrong.", NotificationType.Error);


    }

}

