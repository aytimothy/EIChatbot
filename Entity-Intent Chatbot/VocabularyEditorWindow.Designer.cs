namespace aytimothy.EIChatbot.Editor
{
    partial class VocabularyEditorWindow
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
            this.SynonymsDataView = new System.Windows.Forms.DataGridView();
            this.Words = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SynonymAddButton = new System.Windows.Forms.Button();
            this.SynonymEditButton = new System.Windows.Forms.Button();
            this.SynonymRemoveButton = new System.Windows.Forms.Button();
            this.MeaningLabel = new System.Windows.Forms.Label();
            this.MeaningTextBox = new System.Windows.Forms.TextBox();
            this.GUIDTextBox = new System.Windows.Forms.TextBox();
            this.GUIDLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SynonymsDataView)).BeginInit();
            this.SuspendLayout();
            // 
            // SynonymsDataView
            // 
            this.SynonymsDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SynonymsDataView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Words});
            this.SynonymsDataView.Location = new System.Drawing.Point(12, 12);
            this.SynonymsDataView.Name = "SynonymsDataView";
            this.SynonymsDataView.Size = new System.Drawing.Size(230, 426);
            this.SynonymsDataView.TabIndex = 0;
            // 
            // Words
            // 
            this.Words.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Words.HeaderText = "Synonym";
            this.Words.Name = "Words";
            this.Words.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // SynonymAddButton
            // 
            this.SynonymAddButton.Location = new System.Drawing.Point(248, 12);
            this.SynonymAddButton.Name = "SynonymAddButton";
            this.SynonymAddButton.Size = new System.Drawing.Size(75, 23);
            this.SynonymAddButton.TabIndex = 1;
            this.SynonymAddButton.Text = "Add";
            this.SynonymAddButton.UseVisualStyleBackColor = true;
            // 
            // SynonymEditButton
            // 
            this.SynonymEditButton.Location = new System.Drawing.Point(329, 12);
            this.SynonymEditButton.Name = "SynonymEditButton";
            this.SynonymEditButton.Size = new System.Drawing.Size(75, 23);
            this.SynonymEditButton.TabIndex = 2;
            this.SynonymEditButton.Text = "Edit";
            this.SynonymEditButton.UseVisualStyleBackColor = true;
            // 
            // SynonymRemoveButton
            // 
            this.SynonymRemoveButton.Location = new System.Drawing.Point(410, 12);
            this.SynonymRemoveButton.Name = "SynonymRemoveButton";
            this.SynonymRemoveButton.Size = new System.Drawing.Size(75, 23);
            this.SynonymRemoveButton.TabIndex = 3;
            this.SynonymRemoveButton.Text = "Remove";
            this.SynonymRemoveButton.UseVisualStyleBackColor = true;
            // 
            // MeaningLabel
            // 
            this.MeaningLabel.AutoSize = true;
            this.MeaningLabel.Location = new System.Drawing.Point(248, 44);
            this.MeaningLabel.Name = "MeaningLabel";
            this.MeaningLabel.Size = new System.Drawing.Size(48, 13);
            this.MeaningLabel.TabIndex = 4;
            this.MeaningLabel.Text = "Meaning";
            // 
            // MeaningTextBox
            // 
            this.MeaningTextBox.Location = new System.Drawing.Point(313, 41);
            this.MeaningTextBox.Name = "MeaningTextBox";
            this.MeaningTextBox.Size = new System.Drawing.Size(351, 20);
            this.MeaningTextBox.TabIndex = 5;
            // 
            // GUIDTextBox
            // 
            this.GUIDTextBox.Location = new System.Drawing.Point(313, 67);
            this.GUIDTextBox.Name = "GUIDTextBox";
            this.GUIDTextBox.ReadOnly = true;
            this.GUIDTextBox.Size = new System.Drawing.Size(351, 20);
            this.GUIDTextBox.TabIndex = 7;
            // 
            // GUIDLabel
            // 
            this.GUIDLabel.AutoSize = true;
            this.GUIDLabel.Location = new System.Drawing.Point(248, 70);
            this.GUIDLabel.Name = "GUIDLabel";
            this.GUIDLabel.Size = new System.Drawing.Size(34, 13);
            this.GUIDLabel.TabIndex = 6;
            this.GUIDLabel.Text = "GUID";
            // 
            // VocabularyEditorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 450);
            this.Controls.Add(this.GUIDTextBox);
            this.Controls.Add(this.GUIDLabel);
            this.Controls.Add(this.MeaningTextBox);
            this.Controls.Add(this.MeaningLabel);
            this.Controls.Add(this.SynonymRemoveButton);
            this.Controls.Add(this.SynonymEditButton);
            this.Controls.Add(this.SynonymAddButton);
            this.Controls.Add(this.SynonymsDataView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "VocabularyEditorWindow";
            this.Text = "VocabularyEditorWindow";
            ((System.ComponentModel.ISupportInitialize)(this.SynonymsDataView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView SynonymsDataView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Words;
        private System.Windows.Forms.Button SynonymAddButton;
        private System.Windows.Forms.Button SynonymEditButton;
        private System.Windows.Forms.Button SynonymRemoveButton;
        private System.Windows.Forms.Label MeaningLabel;
        private System.Windows.Forms.TextBox MeaningTextBox;
        private System.Windows.Forms.TextBox GUIDTextBox;
        private System.Windows.Forms.Label GUIDLabel;
    }
}