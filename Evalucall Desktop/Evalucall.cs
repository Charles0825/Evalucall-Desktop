using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Evalucall_Desktop
{
    public partial class Evalucall : Form
    {
        private bool isDragging = false;
        private int xOffset, yOffset;
        private const string EmailPlaceholder = "Enter your email";
        private const string PasswordPlaceholder = "Enter your password";
        private NotificationManager notificationManager;
        private DatabaseManager dbManager;
        private string connectionString;

        public Evalucall()
        {
            InitializeComponent();
            InitializeLoginForm();
            //var appSettings = new AppSettings();
            //connectionString = appSettings.GetConnectionString();
            Task task = InitializeConfiguration();
            notificationManager = new NotificationManager(txtMessage);
            //dbManager = new DatabaseManager(connectionString);
            Console.WriteLine("Connection stringgggg" + connectionString);
        }

        public async Task InitializeConfiguration()
        {
            try
            {
                var appSettings = await AppSettings.CreateAsync();
                connectionString = appSettings.GetConnectionString();
                dbManager = new DatabaseManager(connectionString);
                // Use other methods as needed
                Console.WriteLine("Connection String: " + connectionString);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to initialize AppSettings: " + ex.Message);
            }
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

        private void loginBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string email = txtEmail.Text.Trim();
                string password = txtPassword.Text;

                if (email == EmailPlaceholder)
                {
                    notificationManager.DisplayNotification("Email field cannot be empty", NotificationManager.NType.Error);
                    return;
                }

                if (!Essentials.IsValidEmail(email))
                {
                    notificationManager.DisplayNotification("Please enter a valid email address.", NotificationManager.NType.Error);
                    return;
                }

                if (password == PasswordPlaceholder)
                {
                    notificationManager.DisplayNotification("Password field cannot be empty.", NotificationManager.NType.Error);
                    return;
                }

                string hashedPasswordFromDB = dbManager.RetrieveHashedPassword(email);

                if (hashedPasswordFromDB != null && BCrypt.Net.BCrypt.Verify(password, hashedPasswordFromDB))
                {
                    notificationManager.DisplayNotification("Login successful!", NotificationManager.NType.Success);
                    List<(int id, string firstName, string lastName, string email)> userDetailsList = dbManager.RetrieveUserDetailsFromDatabase(email);

                    if (userDetailsList.Count > 0)
                    {
                        var userDetails = userDetailsList[0];

                        EvalucallRecording evalucallRecording = new EvalucallRecording(userDetails.id, userDetails.firstName + ' ' + userDetails.lastName, userDetails.email);
                        evalucallRecording.Show();
                        this.Hide();
                    }
                    else
                    {
                        Console.WriteLine("No user found with the specified email.");
                    }
                }
                else
                {
                    notificationManager.DisplayNotification("Invalid email or password.", NotificationManager.NType.Error);
                }
            }
            catch (Exception ex)
            {
                notificationManager.DisplayNotification("An error occurred: " + ex.Message , NotificationManager.NType.Error);
            }
        }



        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
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


    }

}

