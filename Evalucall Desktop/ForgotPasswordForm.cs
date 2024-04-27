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
using MySql.Data.MySqlClient;

namespace Evalucall_Desktop
{
    public partial class ForgotPasswordForm : Form
    {
        private const string EmailPlaceholder = "Enter your email";
        private Dictionary<string, string> resetTokens = new Dictionary<string, string>();
        private DatabaseManager dbManager;
        private string connectionString;
        private string weburl;
        private string emailcred;
        private string passcred;
        private NotificationManager notificationManager;
        private AppSettings appSettings;
        public ForgotPasswordForm()
        {
            InitializeComponent();
            InitializeLoginForm();

            //appSettings = new AppSettings();
            //connectionString = appSettings.GetConnectionString();
            Task task = InitializeConfiguration();
            notificationManager = new NotificationManager(txtMessage);
            //dbManager = new DatabaseManager(connectionString);
        }

        public async Task InitializeConfiguration()
        {
            try
            {
                var appSettings = await AppSettings.CreateAsync();
                connectionString = appSettings.GetConnectionString();
                weburl = appSettings.ResetWebsiteURL();
                emailcred = appSettings.GetEmailCred();
                passcred = appSettings.GetPasswordCred();
                dbManager = new DatabaseManager(connectionString);
                Console.WriteLine("Connection String: " + connectionString);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to initialize AppSettings: " + ex.Message);
            }
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


private void emailmeBtn_Click(object sender, EventArgs e)
{
    string email = txtEmail.Text.Trim();

    if (email == EmailPlaceholder)
    {
        notificationManager.DisplayNotification("Email field cannot be empty.", NotificationManager.NType.Error);
        return;
    }

    if (!Essentials.IsValidEmail(email))
    {
        notificationManager.DisplayNotification("Please enter a valid email address.", NotificationManager.NType.Error);
        return;
    }

    if (!dbManager.EmailExists(email))
    {
        notificationManager.DisplayNotification("Email address is not registered.", NotificationManager.NType.Error);
        return;
    }

    string resetToken = dbManager.GeneratePasswordResetToken(email);

    SendPasswordResetEmail(email, resetToken);

    notificationManager.DisplayNotification("Password reset email sent!", NotificationManager.NType.Success);

    ForgotPasswordForm2 forgotPasswordForm2 = new ForgotPasswordForm2(email);
    forgotPasswordForm2.StartPosition = FormStartPosition.CenterParent;
    forgotPasswordForm2.ShowDialog(this);

    this.Close();
}

        private void SendPasswordResetEmail(string email, string resetToken)
        {
            try
            {
                string subject = "Password Reset";
                string body = @"<html>
    <head>
        <style>
            body {
                font-family: Arial, sans-serif;
                background-color: #FFA500;
                color: #ffffff;
                margin: 0;
                padding: 0;
            }
            .container {
                width: 80%;
                margin: 0 auto;
                padding: 20px;
            }
            .content {
                background-color: #ffffff;
                padding: 20px;
                border-radius: 10px;
            }
            .btn {
                background-color: #ffffff;
                color: #FFA500;
                text-decoration: none;
                padding: 10px 20px;
                border-radius: 5px;
            }
        </style>
    </head>
    <body>
        <div class='container'>
            <div class='content'>
                <h2 style='color: #FFA500;'>Dear user,</h2>
                <p>Click the link below to reset your password:</p>
                <p><a href=" + weburl + resetToken + @"' style='background-color: #FFA500; color: #ffffff; text-decoration: none; padding: 10px 20px; border-radius: 5px;'>Reset Password</a></p>
                <p>If you didn't request this, please ignore this email.</p>
            </div>
        </div>
    </body>
    </html>
    ";

                using (System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage())
                {
                    mail.From = new System.Net.Mail.MailAddress(emailcred, "no-reply@evalucall.com");
                    mail.To.Add(email);
                    mail.Subject = subject;
                    mail.Body = body;
                    mail.IsBodyHtml = true;

                    using (System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com"))
                    {
                        smtp.Port = 587;
                        smtp.Credentials = new System.Net.NetworkCredential(emailcred, passcred);
                        smtp.EnableSsl = true;

                        smtp.Send(mail); // This line might throw exceptions

                        notificationManager.DisplayNotification("Password reset email sent!", NotificationManager.NType.Success);
                    }
                }
            }
            catch (Exception ex)
            {
                notificationManager.DisplayNotification($"Error sending email: {ex.Message}", NotificationManager.NType.Error);
            }
        }

    }
}
