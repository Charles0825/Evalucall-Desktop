using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing;
using BCrypt.Net;
using MySql.Data.MySqlClient;

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

            string connectionString = "Server=127.0.0.1;Database=evalucall-database;Uid=root;Pwd=;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT password FROM agents WHERE email = @Email";

                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Email", email);

                    string hashedPasswordFromDB = cmd.ExecuteScalar() as string;

                    if (hashedPasswordFromDB != null && BCrypt.Net.BCrypt.Verify(password, hashedPasswordFromDB))
                    {
                        DisplayNotification("Login successful!", NotificationType.Success);
                        // Retrieve the user ID from the database or any other source
                        int userId = RetrieveUserIdFromDatabase(email);
                        // Pass the user ID to EvalucallRecording form
                        EvalucallRecording evalucallRecording = new EvalucallRecording(userId);
                        evalucallRecording.Show();
                        this.Hide();
                    }
                    else
                    {
                        DisplayNotification("Invalid email or password.", NotificationType.Error);
                    }
                }
                catch (Exception ex)
                {
                    DisplayNotification("Error: " + ex.Message, NotificationType.Error);
                }
            }
        }

        private int RetrieveUserIdFromDatabase(string email)
        {
            int userId = -1; // Default value if user ID is not found or an error occurs

            string connectionString = "Server=127.0.0.1;Database=evalucall-database;Uid=root;Pwd=;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT id FROM agents WHERE email = @Email";

                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Email", email);

                    // ExecuteScalar returns the first column of the first row in the result set
                    // If no rows are found, it returns null
                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        userId = Convert.ToInt32(result); // Convert the result to integer
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions (e.g., log, display error message)
                    Console.WriteLine("Error retrieving user ID: " + ex.Message);
                }
            }

            return userId;
        }


        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
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

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginBtn.PerformClick();
            }
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginBtn.PerformClick();
            }
        }

        public enum NotificationType
        {
            Error,
            Success
        }

        // DisplayNotification("Error: Something went wrong.", NotificationType.Error);


    }

}

