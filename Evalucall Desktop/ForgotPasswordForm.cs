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

    if (!EmailExists(email))
    {
        DisplayNotification("Email address is not registered.", NotificationType.Error);
        return;
    }

    string resetToken = GeneratePasswordResetToken(email);

    SendPasswordResetEmail(email, resetToken);

    DisplayNotification("Password reset email sent!", NotificationType.Success);

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


        private string GeneratePasswordResetToken(string email)
        {
            string token = Guid.NewGuid().ToString("N");

            DateTime tokenExpiry = DateTime.Now.AddMinutes(10);

            string connectionString = "Server=127.0.0.1;Database=evalucall-database;User ID=root;Password=;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "UPDATE agent_accounts SET resetPasswordToken = @ResetToken, resetPasswordExpires = @TokenExpiry WHERE Email = @Email";
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ResetToken", token);
                    cmd.Parameters.AddWithValue("@TokenExpiry", tokenExpiry);
                    cmd.Parameters.AddWithValue("@Email", email);

                    cmd.ExecuteNonQuery();
                }
            }

            return token;
        }


        private void SendPasswordResetEmail(string email, string resetToken)
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
            <p><a href='https://yourwebsite.com/reset?token=" + resetToken + @"' style='background-color: #FFA500; color: #ffffff; text-decoration: none; padding: 10px 20px; border-radius: 5px;'>Reset Password</a></p>
            <p>If you didn't request this, please ignore this email.</p>
        </div>
    </div>
</body>
</html>
";

            using (System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage())
            {
                mail.From = new System.Net.Mail.MailAddress("evalucallsystem@gmail.com", "no-reply@evalucall.com");
                mail.To.Add(email);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;

                using (System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com"))
                {
                    smtp.Port = 587;
                    smtp.Credentials = new System.Net.NetworkCredential("evalucallsystem@gmail.com", "bmih asgr ltvt iqzr"); // Use your Gmail address and password
                    smtp.EnableSsl = true;

                    try
                    {
                        smtp.Send(mail);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error sending email: {ex.Message}");
                    }
                }
            }
        }


        private bool EmailExists(string email)
        {
            string connectionString = "Server=127.0.0.1;Database=evalucall-database;User ID=root;Password=;";
            
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM agent_accounts WHERE Email = @Email";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    return false;
                }
            }
        }


    }
}
