
namespace Evalucall_Desktop
{
    partial class EvalucallRecording
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EvalucallRecording));
            this.closeBtn = new System.Windows.Forms.PictureBox();
            this.minimizeBtn = new System.Windows.Forms.PictureBox();
            this.topbar = new System.Windows.Forms.PictureBox();
            this.RecordBtn = new System.Windows.Forms.PictureBox();
            this.RecordDuration = new System.Windows.Forms.Label();
            this.RecordNotification = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.closeBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimizeBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.topbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RecordBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // closeBtn
            // 
            this.closeBtn.BackColor = System.Drawing.Color.White;
            this.closeBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.closeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeBtn.Image = ((System.Drawing.Image)(resources.GetObject("closeBtn.Image")));
            this.closeBtn.Location = new System.Drawing.Point(460, 3);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(24, 24);
            this.closeBtn.TabIndex = 2;
            this.closeBtn.TabStop = false;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // minimizeBtn
            // 
            this.minimizeBtn.BackColor = System.Drawing.Color.White;
            this.minimizeBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.minimizeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.minimizeBtn.Image = ((System.Drawing.Image)(resources.GetObject("minimizeBtn.Image")));
            this.minimizeBtn.Location = new System.Drawing.Point(425, 3);
            this.minimizeBtn.Name = "minimizeBtn";
            this.minimizeBtn.Size = new System.Drawing.Size(24, 24);
            this.minimizeBtn.TabIndex = 3;
            this.minimizeBtn.TabStop = false;
            this.minimizeBtn.Click += new System.EventHandler(this.minimizeBtn_Click);
            // 
            // topbar
            // 
            this.topbar.BackColor = System.Drawing.Color.Transparent;
            this.topbar.Cursor = System.Windows.Forms.Cursors.Default;
            this.topbar.Image = ((System.Drawing.Image)(resources.GetObject("topbar.Image")));
            this.topbar.Location = new System.Drawing.Point(0, 0);
            this.topbar.Name = "topbar";
            this.topbar.Size = new System.Drawing.Size(500, 31);
            this.topbar.TabIndex = 4;
            this.topbar.TabStop = false;
            this.topbar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.topbar_MouseDown);
            this.topbar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.topbar_MouseMove);
            this.topbar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.topbar_MouseUp);
            // 
            // RecordBtn
            // 
            this.RecordBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RecordBtn.Image = ((System.Drawing.Image)(resources.GetObject("RecordBtn.Image")));
            this.RecordBtn.Location = new System.Drawing.Point(170, 271);
            this.RecordBtn.MaximumSize = new System.Drawing.Size(160, 160);
            this.RecordBtn.MinimumSize = new System.Drawing.Size(160, 160);
            this.RecordBtn.Name = "RecordBtn";
            this.RecordBtn.Size = new System.Drawing.Size(160, 160);
            this.RecordBtn.TabIndex = 5;
            this.RecordBtn.TabStop = false;
            this.RecordBtn.Click += new System.EventHandler(this.RecordBtn_Click);
            // 
            // RecordDuration
            // 
            this.RecordDuration.AutoSize = true;
            this.RecordDuration.Font = new System.Drawing.Font("Poppins", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RecordDuration.Location = new System.Drawing.Point(125, 174);
            this.RecordDuration.Name = "RecordDuration";
            this.RecordDuration.Size = new System.Drawing.Size(249, 84);
            this.RecordDuration.TabIndex = 6;
            this.RecordDuration.Text = "00:00:00";
            // 
            // RecordNotification
            // 
            this.RecordNotification.AutoSize = true;
            this.RecordNotification.Font = new System.Drawing.Font("Poppins SemiBold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RecordNotification.Location = new System.Drawing.Point(169, 444);
            this.RecordNotification.MaximumSize = new System.Drawing.Size(160, 25);
            this.RecordNotification.MinimumSize = new System.Drawing.Size(160, 25);
            this.RecordNotification.Name = "RecordNotification";
            this.RecordNotification.Size = new System.Drawing.Size(160, 25);
            this.RecordNotification.TabIndex = 7;
            this.RecordNotification.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EvalucallRecording
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 600);
            this.Controls.Add(this.RecordNotification);
            this.Controls.Add(this.RecordDuration);
            this.Controls.Add(this.RecordBtn);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.minimizeBtn);
            this.Controls.Add(this.topbar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(500, 600);
            this.MinimumSize = new System.Drawing.Size(500, 600);
            this.Name = "EvalucallRecording";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EvalucallRecording";
            ((System.ComponentModel.ISupportInitialize)(this.closeBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimizeBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.topbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RecordBtn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox closeBtn;
        private System.Windows.Forms.PictureBox minimizeBtn;
        private System.Windows.Forms.PictureBox topbar;
        private System.Windows.Forms.PictureBox RecordBtn;
        private System.Windows.Forms.Label RecordDuration;
        private System.Windows.Forms.Label RecordNotification;
    }
}