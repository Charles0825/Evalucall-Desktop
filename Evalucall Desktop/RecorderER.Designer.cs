
namespace Evalucall_Desktop
{
    partial class RecorderER
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecorderER));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.uploadingrecentcalls = new System.Windows.Forms.Label();
            this.progBack = new System.Windows.Forms.PictureBox();
            this.progressBar = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.progPercentage = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.progBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBar)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Poppins", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(46)))), ((int)(((byte)(65)))));
            this.label1.Location = new System.Drawing.Point(14, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Voice Recorder";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(205, 600);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.Controls.Add(this.progPercentage);
            this.panel2.Controls.Add(this.progressBar);
            this.panel2.Controls.Add(this.progBack);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.uploadingrecentcalls);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(220, 50);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(762, 532);
            this.panel2.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Poppins SemiBold", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(46)))), ((int)(((byte)(65)))));
            this.label2.Location = new System.Drawing.Point(208, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(328, 113);
            this.label2.TabIndex = 1;
            this.label2.Text = "00:00:00";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(297, 204);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 150);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Poppins Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(46)))), ((int)(((byte)(65)))));
            this.label3.Location = new System.Drawing.Point(596, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "Server status : Online";
            // 
            // uploadingrecentcalls
            // 
            this.uploadingrecentcalls.AutoSize = true;
            this.uploadingrecentcalls.BackColor = System.Drawing.Color.Transparent;
            this.uploadingrecentcalls.Font = new System.Drawing.Font("Poppins Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uploadingrecentcalls.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(46)))), ((int)(((byte)(65)))));
            this.uploadingrecentcalls.Location = new System.Drawing.Point(272, 458);
            this.uploadingrecentcalls.Name = "uploadingrecentcalls";
            this.uploadingrecentcalls.Size = new System.Drawing.Size(201, 23);
            this.uploadingrecentcalls.TabIndex = 0;
            this.uploadingrecentcalls.Text = "Uploading recent calls . . .\r\n";
            this.uploadingrecentcalls.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progBack
            // 
            this.progBack.Image = ((System.Drawing.Image)(resources.GetObject("progBack.Image")));
            this.progBack.Location = new System.Drawing.Point(122, 485);
            this.progBack.MaximumSize = new System.Drawing.Size(501, 21);
            this.progBack.MinimumSize = new System.Drawing.Size(501, 21);
            this.progBack.Name = "progBack";
            this.progBack.Size = new System.Drawing.Size(501, 21);
            this.progBack.TabIndex = 3;
            this.progBack.TabStop = false;
            // 
            // progressBar
            // 
            this.progressBar.Image = ((System.Drawing.Image)(resources.GetObject("progressBar.Image")));
            this.progressBar.Location = new System.Drawing.Point(122, 485);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(10, 21);
            this.progressBar.TabIndex = 4;
            this.progressBar.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // progPercentage
            // 
            this.progPercentage.AutoSize = true;
            this.progPercentage.BackColor = System.Drawing.Color.Transparent;
            this.progPercentage.Font = new System.Drawing.Font("Poppins Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progPercentage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(46)))), ((int)(((byte)(65)))));
            this.progPercentage.Location = new System.Drawing.Point(353, 438);
            this.progPercentage.Name = "progPercentage";
            this.progPercentage.Size = new System.Drawing.Size(39, 23);
            this.progPercentage.TabIndex = 5;
            this.progPercentage.Text = "34%";
            this.progPercentage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RecorderER
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RecorderER";
            this.Text = "Form1";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.progBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox progressBar;
        private System.Windows.Forms.PictureBox progBack;
        private System.Windows.Forms.Label uploadingrecentcalls;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label progPercentage;
    }
}