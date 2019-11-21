namespace aytimothy.EIChatbot.Editor
{
    partial class MainWindow
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
            this.NewButton = new System.Windows.Forms.Button();
            this.OpenButton = new System.Windows.Forms.Button();
            this.PreferencesButton = new System.Windows.Forms.Button();
            this.QuitButton = new System.Windows.Forms.Button();
            this.AboutLinkLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // TitleLabel
            // 
            this.TitleLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.Location = new System.Drawing.Point(12, 9);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(218, 54);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "TitleLabel";
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NewButton
            // 
            this.NewButton.Location = new System.Drawing.Point(16, 66);
            this.NewButton.Name = "NewButton";
            this.NewButton.Size = new System.Drawing.Size(214, 51);
            this.NewButton.TabIndex = 1;
            this.NewButton.Text = "NewButton";
            this.NewButton.UseVisualStyleBackColor = true;
            this.NewButton.Click += new System.EventHandler(this.NewButton_Click);
            // 
            // OpenButton
            // 
            this.OpenButton.Location = new System.Drawing.Point(16, 123);
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.Size = new System.Drawing.Size(214, 51);
            this.OpenButton.TabIndex = 2;
            this.OpenButton.Text = "OpenButton";
            this.OpenButton.UseVisualStyleBackColor = true;
            this.OpenButton.Click += new System.EventHandler(this.OpenButton_Click);
            // 
            // PreferencesButton
            // 
            this.PreferencesButton.Location = new System.Drawing.Point(16, 180);
            this.PreferencesButton.Name = "PreferencesButton";
            this.PreferencesButton.Size = new System.Drawing.Size(214, 51);
            this.PreferencesButton.TabIndex = 3;
            this.PreferencesButton.Text = "PreferencesButton";
            this.PreferencesButton.UseVisualStyleBackColor = true;
            this.PreferencesButton.Click += new System.EventHandler(this.PreferencesButton_Click);
            // 
            // QuitButton
            // 
            this.QuitButton.Location = new System.Drawing.Point(16, 237);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(214, 51);
            this.QuitButton.TabIndex = 4;
            this.QuitButton.Text = "QuitButton";
            this.QuitButton.UseVisualStyleBackColor = true;
            this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // AboutLinkLabel
            // 
            this.AboutLinkLabel.Location = new System.Drawing.Point(16, 291);
            this.AboutLinkLabel.Name = "AboutLinkLabel";
            this.AboutLinkLabel.Size = new System.Drawing.Size(214, 23);
            this.AboutLinkLabel.TabIndex = 5;
            this.AboutLinkLabel.TabStop = true;
            this.AboutLinkLabel.Text = "AboutLinkLabel";
            this.AboutLinkLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.AboutLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.AboutLinkLabel_LinkClicked);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 326);
            this.Controls.Add(this.AboutLinkLabel);
            this.Controls.Add(this.QuitButton);
            this.Controls.Add(this.PreferencesButton);
            this.Controls.Add(this.OpenButton);
            this.Controls.Add(this.NewButton);
            this.Controls.Add(this.TitleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "aytimothy\'s EIChatbot Editor";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Button NewButton;
        private System.Windows.Forms.Button OpenButton;
        private System.Windows.Forms.Button PreferencesButton;
        private System.Windows.Forms.Button QuitButton;
        private System.Windows.Forms.LinkLabel AboutLinkLabel;
    }
}

