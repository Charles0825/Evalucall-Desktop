
namespace Evalucall_Desktop
{
    partial class ForgotPasswordForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ForgotPasswordForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.emailmeBtn = new System.Windows.Forms.Button();
            this.backBtn = new System.Windows.Forms.PictureBox();
            this.txtMessage = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.backBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Poppins SemiBold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(96, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Reset your password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(84, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(260, 69);
            this.label2.TabIndex = 4;
            this.label2.Text = "We will send you an email to reset your \r\npassword.\r\n\r\n";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.Controls.Add(this.txtEmail);
            this.panel2.Location = new System.Drawing.Point(64, 180);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.MaximumSize = new System.Drawing.Size(300, 35);
            this.panel2.MinimumSize = new System.Drawing.Size(300, 35);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(300, 35);
            this.panel2.TabIndex = 5;
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEmail.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(13, 6);
            this.txtEmail.MaximumSize = new System.Drawing.Size(274, 24);
            this.txtEmail.MinimumSize = new System.Drawing.Size(274, 24);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(274, 23);
            this.txtEmail.TabIndex = 5;
            this.txtEmail.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(59, 155);
            this.label3.Margin = new System.Windows.Forms.Padding(2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 26);
            this.label3.TabIndex = 1;
            this.label3.Text = "Email";
            // 
            // emailmeBtn
            // 
            this.emailmeBtn.BackColor = System.Drawing.Color.Transparent;
            this.emailmeBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("emailmeBtn.BackgroundImage")));
            this.emailmeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.emailmeBtn.FlatAppearance.BorderSize = 0;
            this.emailmeBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.emailmeBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.emailmeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.emailmeBtn.Location = new System.Drawing.Point(64, 253);
            this.emailmeBtn.MaximumSize = new System.Drawing.Size(300, 35);
            this.emailmeBtn.MinimumSize = new System.Drawing.Size(300, 35);
            this.emailmeBtn.Name = "emailmeBtn";
            this.emailmeBtn.Size = new System.Drawing.Size(300, 35);
            this.emailmeBtn.TabIndex = 6;
            this.emailmeBtn.UseVisualStyleBackColor = false;
            this.emailmeBtn.Click += new System.EventHandler(this.emailmeBtn_Click);
            // 
            // backBtn
            // 
            this.backBtn.BackColor = System.Drawing.Color.Transparent;
            this.backBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.backBtn.Image = ((System.Drawing.Image)(resources.GetObject("backBtn.Image")));
            this.backBtn.Location = new System.Drawing.Point(64, 58);
            this.backBtn.MaximumSize = new System.Drawing.Size(24, 24);
            this.backBtn.MinimumSize = new System.Drawing.Size(24, 24);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(24, 24);
            this.backBtn.TabIndex = 6;
            this.backBtn.TabStop = false;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.AutoSize = true;
            this.txtMessage.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessage.Location = new System.Drawing.Point(64, 223);
            this.txtMessage.MaximumSize = new System.Drawing.Size(300, 23);
            this.txtMessage.MinimumSize = new System.Drawing.Size(300, 23);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(300, 23);
            this.txtMessage.TabIndex = 7;
            this.txtMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ForgotPasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(428, 333);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.emailmeBtn);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(428, 333);
            this.MinimumSize = new System.Drawing.Size(428, 333);
            this.Name = "ForgotPasswordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrogotPassword";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.backBtn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button emailmeBtn;
        private System.Windows.Forms.PictureBox backBtn;
        private System.Windows.Forms.Label txtMessage;
    }
}