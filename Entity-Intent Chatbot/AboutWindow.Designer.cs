namespace aytimothy.EIChatbot.Editor
{
    partial class AboutWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.TitleLabel = new System.Windows.Forms.Label();
            this.VersionLabel = new System.Windows.Forms.Label();
            this.Line1Label = new System.Windows.Forms.Label();
            this.Line2Label = new System.Windows.Forms.Label();
            this.ParagraphLabel = new System.Windows.Forms.Label();
            this.Line3Label = new System.Windows.Forms.Label();
            this.LinkLabel1 = new System.Windows.Forms.LinkLabel();
            this.CloseLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TitleLabel
            // 
            this.TitleLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.Location = new System.Drawing.Point(12, 9);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(341, 47);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "TitleLabel";
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TitleLabel.Click += new System.EventHandler(this.TitleLabel_Click);
            // 
            // VersionLabel
            // 
            this.VersionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.VersionLabel.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VersionLabel.Location = new System.Drawing.Point(12, 56);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.Size = new System.Drawing.Size(340, 23);
            this.VersionLabel.TabIndex = 1;
            this.VersionLabel.Text = "VersionLabel";
            this.VersionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.VersionLabel.Click += new System.EventHandler(this.VersionLabel_Click);
            // 
            // Line1Label
            // 
            this.Line1Label.AutoSize = true;
            this.Line1Label.Location = new System.Drawing.Point(12, 94);
            this.Line1Label.Name = "Line1Label";
            this.Line1Label.Size = new System.Drawing.Size(59, 13);
            this.Line1Label.TabIndex = 2;
            this.Line1Label.Text = "Line1Label";
            this.Line1Label.Click += new System.EventHandler(this.Line1Label_Click);
            // 
            // Line2Label
            // 
            this.Line2Label.AutoSize = true;
            this.Line2Label.Location = new System.Drawing.Point(13, 116);
            this.Line2Label.Name = "Line2Label";
            this.Line2Label.Size = new System.Drawing.Size(59, 13);
            this.Line2Label.TabIndex = 3;
            this.Line2Label.Text = "Line2Label";
            this.Line2Label.Click += new System.EventHandler(this.Line2Label_Click);
            // 
            // ParagraphLabel
            // 
            this.ParagraphLabel.Location = new System.Drawing.Point(12, 143);
            this.ParagraphLabel.Name = "ParagraphLabel";
            this.ParagraphLabel.Size = new System.Drawing.Size(341, 163);
            this.ParagraphLabel.TabIndex = 4;
            this.ParagraphLabel.Text = "ParagraphLabel";
            this.ParagraphLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ParagraphLabel.Click += new System.EventHandler(this.ParagraphLabel_Click);
            // 
            // Line3Label
            // 
            this.Line3Label.AutoSize = true;
            this.Line3Label.Location = new System.Drawing.Point(13, 315);
            this.Line3Label.Name = "Line3Label";
            this.Line3Label.Size = new System.Drawing.Size(59, 13);
            this.Line3Label.TabIndex = 5;
            this.Line3Label.Text = "Line3Label";
            this.Line3Label.Click += new System.EventHandler(this.Line3Label_Click);
            // 
            // LinkLabel1
            // 
            this.LinkLabel1.Location = new System.Drawing.Point(11, 337);
            this.LinkLabel1.Name = "LinkLabel1";
            this.LinkLabel1.Size = new System.Drawing.Size(341, 17);
            this.LinkLabel1.TabIndex = 6;
            this.LinkLabel1.TabStop = true;
            this.LinkLabel1.Text = "LinkLabel1";
            this.LinkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LinkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // CloseLabel
            // 
            this.CloseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseLabel.Location = new System.Drawing.Point(13, 364);
            this.CloseLabel.Name = "CloseLabel";
            this.CloseLabel.Size = new System.Drawing.Size(339, 23);
            this.CloseLabel.TabIndex = 7;
            this.CloseLabel.Text = "CloseLabel";
            this.CloseLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CloseLabel.Click += new System.EventHandler(this.CloseLabel_Click);
            // 
            // AboutWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 399);
            this.Controls.Add(this.CloseLabel);
            this.Controls.Add(this.LinkLabel1);
            this.Controls.Add(this.Line3Label);
            this.Controls.Add(this.ParagraphLabel);
            this.Controls.Add(this.Line2Label);
            this.Controls.Add(this.Line1Label);
            this.Controls.Add(this.VersionLabel);
            this.Controls.Add(this.TitleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AboutWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About EIChatbot Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AboutWindow_FormClosing);
            this.Click += new System.EventHandler(this.AboutWindow_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label VersionLabel;
        private System.Windows.Forms.Label Line1Label;
        private System.Windows.Forms.Label Line2Label;
        private System.Windows.Forms.Label ParagraphLabel;
        private System.Windows.Forms.Label Line3Label;
        private System.Windows.Forms.LinkLabel LinkLabel1;
        private System.Windows.Forms.Label CloseLabel;
    }
}