
namespace Evalucall_Desktop
{
    partial class ForgotPasswordForm2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ForgotPasswordForm2));
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.backBtn = new System.Windows.Forms.PictureBox();
            this.TxtBackLogin = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.backBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoEllipsis = true;
            this.linkLabel1.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel1.Location = new System.Drawing.Point(22, 28);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(374, 241);
            this.linkLabel1.TabIndex = 1;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "A password reset email has been sent to sample@gmail.com, If it exists in our sys" +
    "tem. Resend or change email";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1_LinkClicked);
            // 
            // backBtn
            // 
            this.backBtn.BackColor = System.Drawing.Color.Transparent;
            this.backBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.backBtn.Image = ((System.Drawing.Image)(resources.GetObject("backBtn.Image")));
            this.backBtn.Location = new System.Drawing.Point(178, 281);
            this.backBtn.MaximumSize = new System.Drawing.Size(24, 24);
            this.backBtn.MinimumSize = new System.Drawing.Size(24, 24);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(24, 24);
            this.backBtn.TabIndex = 7;
            this.backBtn.TabStop = false;
            // 
            // TxtBackLogin
            // 
            this.TxtBackLogin.AutoSize = true;
            this.TxtBackLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TxtBackLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TxtBackLogin.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBackLogin.Location = new System.Drawing.Point(199, 281);
            this.TxtBackLogin.Name = "TxtBackLogin";
            this.TxtBackLogin.Size = new System.Drawing.Size(52, 26);
            this.TxtBackLogin.TabIndex = 8;
            this.TxtBackLogin.Text = "Login";
            this.TxtBackLogin.Click += new System.EventHandler(this.TxtBackLogin_Click);
            // 
            // ForgotPasswordForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(428, 333);
            this.Controls.Add(this.TxtBackLogin);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.linkLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(428, 333);
            this.MinimumSize = new System.Drawing.Size(428, 333);
            this.Name = "ForgotPasswordForm2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.backBtn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.PictureBox backBtn;
        private System.Windows.Forms.Label TxtBackLogin;
    }
}