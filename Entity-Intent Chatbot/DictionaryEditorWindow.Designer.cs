namespace aytimothy.EIChatbot.Editor
{
    partial class DictionaryEditorWindow
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.VocabularyAddButton = new System.Windows.Forms.Button();
            this.VocabularyEditButton = new System.Windows.Forms.Button();
            this.VocabularyRemoveButton = new System.Windows.Forms.Button();
            this.NameLabel = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.DescriptionTextBox = new System.Windows.Forms.TextBox();
            this.DictionaryLabel = new System.Windows.Forms.Label();
            this.GUIDTextBox = new System.Windows.Forms.TextBox();
            this.GUIDLabel = new System.Windows.Forms.Label();
            this.VocabularyGUID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VocabularyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VocabularySynonyms = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VocabularySize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.VocabularyGUID,
            this.VocabularyName,
            this.VocabularySynonyms,
            this.VocabularySize});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(425, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // VocabularyAddButton
            // 
            this.VocabularyAddButton.Location = new System.Drawing.Point(12, 168);
            this.VocabularyAddButton.Name = "VocabularyAddButton";
            this.VocabularyAddButton.Size = new System.Drawing.Size(75, 23);
            this.VocabularyAddButton.TabIndex = 1;
            this.VocabularyAddButton.Text = "Add";
            this.VocabularyAddButton.UseVisualStyleBackColor = true;
            // 
            // VocabularyEditButton
            // 
            this.VocabularyEditButton.Location = new System.Drawing.Point(93, 168);
            this.VocabularyEditButton.Name = "VocabularyEditButton";
            this.VocabularyEditButton.Size = new System.Drawing.Size(75, 23);
            this.VocabularyEditButton.TabIndex = 2;
            this.VocabularyEditButton.Text = "Edit";
            this.VocabularyEditButton.UseVisualStyleBackColor = true;
            // 
            // VocabularyRemoveButton
            // 
            this.VocabularyRemoveButton.Location = new System.Drawing.Point(174, 168);
            this.VocabularyRemoveButton.Name = "VocabularyRemoveButton";
            this.VocabularyRemoveButton.Size = new System.Drawing.Size(75, 23);
            this.VocabularyRemoveButton.TabIndex = 3;
            this.VocabularyRemoveButton.Text = "Remove";
            this.VocabularyRemoveButton.UseVisualStyleBackColor = true;
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(12, 217);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(35, 13);
            this.NameLabel.TabIndex = 4;
            this.NameLabel.Text = "Name";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(76, 214);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(361, 20);
            this.NameTextBox.TabIndex = 5;
            // 
            // DescriptionTextBox
            // 
            this.DescriptionTextBox.Location = new System.Drawing.Point(76, 240);
            this.DescriptionTextBox.Name = "DescriptionTextBox";
            this.DescriptionTextBox.Size = new System.Drawing.Size(361, 20);
            this.DescriptionTextBox.TabIndex = 7;
            // 
            // DictionaryLabel
            // 
            this.DictionaryLabel.AutoSize = true;
            this.DictionaryLabel.Location = new System.Drawing.Point(12, 243);
            this.DictionaryLabel.Name = "DictionaryLabel";
            this.DictionaryLabel.Size = new System.Drawing.Size(60, 13);
            this.DictionaryLabel.TabIndex = 6;
            this.DictionaryLabel.Text = "Description";
            // 
            // GUIDTextBox
            // 
            this.GUIDTextBox.Location = new System.Drawing.Point(76, 266);
            this.GUIDTextBox.Name = "GUIDTextBox";
            this.GUIDTextBox.ReadOnly = true;
            this.GUIDTextBox.Size = new System.Drawing.Size(361, 20);
            this.GUIDTextBox.TabIndex = 9;
            // 
            // GUIDLabel
            // 
            this.GUIDLabel.AutoSize = true;
            this.GUIDLabel.Location = new System.Drawing.Point(12, 269);
            this.GUIDLabel.Name = "GUIDLabel";
            this.GUIDLabel.Size = new System.Drawing.Size(34, 13);
            this.GUIDLabel.TabIndex = 8;
            this.GUIDLabel.Text = "GUID";
            // 
            // VocabularyGUID
            // 
            this.VocabularyGUID.HeaderText = "GUID";
            this.VocabularyGUID.Name = "VocabularyGUID";
            // 
            // VocabularyName
            // 
            this.VocabularyName.HeaderText = "Word";
            this.VocabularyName.Name = "VocabularyName";
            // 
            // VocabularySynonyms
            // 
            this.VocabularySynonyms.HeaderText = "Synonyms";
            this.VocabularySynonyms.Name = "VocabularySynonyms";
            // 
            // VocabularySize
            // 
            this.VocabularySize.HeaderText = "Count";
            this.VocabularySize.Name = "VocabularySize";
            // 
            // DictionaryEditorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 300);
            this.Controls.Add(this.GUIDTextBox);
            this.Controls.Add(this.GUIDLabel);
            this.Controls.Add(this.DescriptionTextBox);
            this.Controls.Add(this.DictionaryLabel);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.VocabularyRemoveButton);
            this.Controls.Add(this.VocabularyEditButton);
            this.Controls.Add(this.VocabularyAddButton);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DictionaryEditorWindow";
            this.Text = "DictionaryEditorWindow";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button VocabularyAddButton;
        private System.Windows.Forms.Button VocabularyEditButton;
        private System.Windows.Forms.Button VocabularyRemoveButton;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.TextBox DescriptionTextBox;
        private System.Windows.Forms.Label DictionaryLabel;
        private System.Windows.Forms.TextBox GUIDTextBox;
        private System.Windows.Forms.Label GUIDLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn VocabularyGUID;
        private System.Windows.Forms.DataGridViewTextBoxColumn VocabularyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn VocabularySynonyms;
        private System.Windows.Forms.DataGridViewTextBoxColumn VocabularySize;
    }
}