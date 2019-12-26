namespace aytimothy.EIChatbot.Editor
{
    partial class ShapeEditorWindow
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
            this.NotImplementedLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // NotImplementedLabel
            // 
            this.NotImplementedLabel.AutoEllipsis = true;
            this.NotImplementedLabel.Location = new System.Drawing.Point(18, 14);
            this.NotImplementedLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.NotImplementedLabel.Name = "NotImplementedLabel";
            this.NotImplementedLabel.Size = new System.Drawing.Size(790, 514);
            this.NotImplementedLabel.TabIndex = 0;
            this.NotImplementedLabel.Text = "Not Implemented";
            this.NotImplementedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ShapeEditorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 542);
            this.Controls.Add(this.NotImplementedLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ShapeEditorWindow";
            this.Text = "Shape Editor";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label NotImplementedLabel;
    }
}