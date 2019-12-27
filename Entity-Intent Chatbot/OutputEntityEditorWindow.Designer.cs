namespace aytimothy.EIChatbot.Editor
{
    partial class OutputEntityEditorWindow
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
            this.GUIDLabel = new System.Windows.Forms.Label();
            this.GUIDTextBox = new System.Windows.Forms.TextBox();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.NameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // GUIDLabel
            // 
            this.GUIDLabel.AutoSize = true;
            this.GUIDLabel.Location = new System.Drawing.Point(12, 47);
            this.GUIDLabel.Name = "GUIDLabel";
            this.GUIDLabel.Size = new System.Drawing.Size(51, 20);
            this.GUIDLabel.TabIndex = 2;
            this.GUIDLabel.Text = "GUID";
            // 
            // GUIDTextBox
            // 
            this.GUIDTextBox.Location = new System.Drawing.Point(163, 44);
            this.GUIDTextBox.Name = "GUIDTextBox";
            this.GUIDTextBox.ReadOnly = true;
            this.GUIDTextBox.Size = new System.Drawing.Size(391, 26);
            this.GUIDTextBox.TabIndex = 3;
            this.GUIDTextBox.TextChanged += new System.EventHandler(this.GUIDTextBox_TextChanged);
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(163, 12);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(391, 26);
            this.NameTextBox.TabIndex = 11;
            this.NameTextBox.TextChanged += new System.EventHandler(this.NameTextBox_TextChanged);
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(12, 15);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(51, 20);
            this.NameLabel.TabIndex = 10;
            this.NameLabel.Text = "Name";
            // 
            // OutputEntityEditorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 83);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.GUIDTextBox);
            this.Controls.Add(this.GUIDLabel);
            this.Name = "OutputEntityEditorWindow";
            this.Text = "Output Entity Editor";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OutputEntityEditorWindow_FormClosed);
            this.Load += new System.EventHandler(this.OutputEntityEditorWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label GUIDLabel;
        private System.Windows.Forms.TextBox GUIDTextBox;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Label NameLabel;
    }
}