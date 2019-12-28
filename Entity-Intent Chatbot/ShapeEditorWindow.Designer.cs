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
            this.ShapeTextBox = new System.Windows.Forms.TextBox();
            this.ShapeLabel = new System.Windows.Forms.Label();
            this.EntityCountLabel = new System.Windows.Forms.Label();
            this.EntityTabControl = new System.Windows.Forms.TabControl();
            this.TemplateTabPage = new System.Windows.Forms.TabPage();
            this.TemplatePartialThresholdLabel = new System.Windows.Forms.Label();
            this.TemplatePartialThresholdTextBox = new System.Windows.Forms.TextBox();
            this.TemplateOutputEntitySlotComboBox = new System.Windows.Forms.ComboBox();
            this.TemplateOutputEntitySlotLabel = new System.Windows.Forms.Label();
            this.TemplateIsOutputEntityCheckBox = new System.Windows.Forms.CheckBox();
            this.TemplateMatchStringDictionaryComboBox = new System.Windows.Forms.ComboBox();
            this.TemplateSourceStringLabel = new System.Windows.Forms.Label();
            this.TemplateSourceStringTextBox = new System.Windows.Forms.TextBox();
            this.TemplateMatchStringTextBox = new System.Windows.Forms.TextBox();
            this.TemplateMatchStringLabel = new System.Windows.Forms.Label();
            this.TemplateTypeComboBox = new System.Windows.Forms.ComboBox();
            this.TemplateTypeLabel = new System.Windows.Forms.Label();
            this.GUIDTextBox = new System.Windows.Forms.TextBox();
            this.LanguageComboBox = new System.Windows.Forms.ComboBox();
            this.GUIDLabel = new System.Windows.Forms.Label();
            this.LanguageLabel = new System.Windows.Forms.Label();
            this.EntityTabControl.SuspendLayout();
            this.TemplateTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // ShapeTextBox
            // 
            this.ShapeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShapeTextBox.Location = new System.Drawing.Point(8, 21);
            this.ShapeTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.ShapeTextBox.Name = "ShapeTextBox";
            this.ShapeTextBox.Size = new System.Drawing.Size(536, 44);
            this.ShapeTextBox.TabIndex = 0;
            this.ShapeTextBox.TextChanged += new System.EventHandler(this.ShapeText_TextChanged);
            this.ShapeTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ShapeText_KeyPress);
            this.ShapeTextBox.Leave += new System.EventHandler(this.ShapeText_Leave);
            this.ShapeTextBox.LostFocus += new System.EventHandler(this.ShapeText_LostFocus);
            // 
            // ShapeLabel
            // 
            this.ShapeLabel.AutoSize = true;
            this.ShapeLabel.Location = new System.Drawing.Point(8, 6);
            this.ShapeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ShapeLabel.Name = "ShapeLabel";
            this.ShapeLabel.Size = new System.Drawing.Size(34, 13);
            this.ShapeLabel.TabIndex = 1;
            this.ShapeLabel.Text = "String";
            // 
            // EntityCountLabel
            // 
            this.EntityCountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EntityCountLabel.AutoSize = true;
            this.EntityCountLabel.Location = new System.Drawing.Point(8, 67);
            this.EntityCountLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.EntityCountLabel.Name = "EntityCountLabel";
            this.EntityCountLabel.Size = new System.Drawing.Size(68, 13);
            this.EntityCountLabel.TabIndex = 2;
            this.EntityCountLabel.Text = "Entities: ###";
            // 
            // EntityTabControl
            // 
            this.EntityTabControl.Controls.Add(this.TemplateTabPage);
            this.EntityTabControl.Location = new System.Drawing.Point(10, 94);
            this.EntityTabControl.Margin = new System.Windows.Forms.Padding(2);
            this.EntityTabControl.Name = "EntityTabControl";
            this.EntityTabControl.SelectedIndex = 0;
            this.EntityTabControl.Size = new System.Drawing.Size(532, 255);
            this.EntityTabControl.TabIndex = 3;
            this.EntityTabControl.TabIndexChanged += new System.EventHandler(this.EntityTabControl_TabIndexChanged);
            // 
            // TemplateTabPage
            // 
            this.TemplateTabPage.Controls.Add(this.TemplatePartialThresholdLabel);
            this.TemplateTabPage.Controls.Add(this.TemplatePartialThresholdTextBox);
            this.TemplateTabPage.Controls.Add(this.TemplateOutputEntitySlotComboBox);
            this.TemplateTabPage.Controls.Add(this.TemplateOutputEntitySlotLabel);
            this.TemplateTabPage.Controls.Add(this.TemplateIsOutputEntityCheckBox);
            this.TemplateTabPage.Controls.Add(this.TemplateMatchStringDictionaryComboBox);
            this.TemplateTabPage.Controls.Add(this.TemplateSourceStringLabel);
            this.TemplateTabPage.Controls.Add(this.TemplateSourceStringTextBox);
            this.TemplateTabPage.Controls.Add(this.TemplateMatchStringTextBox);
            this.TemplateTabPage.Controls.Add(this.TemplateMatchStringLabel);
            this.TemplateTabPage.Controls.Add(this.TemplateTypeComboBox);
            this.TemplateTabPage.Controls.Add(this.TemplateTypeLabel);
            this.TemplateTabPage.Location = new System.Drawing.Point(4, 22);
            this.TemplateTabPage.Margin = new System.Windows.Forms.Padding(2);
            this.TemplateTabPage.Name = "TemplateTabPage";
            this.TemplateTabPage.Padding = new System.Windows.Forms.Padding(2);
            this.TemplateTabPage.Size = new System.Drawing.Size(524, 229);
            this.TemplateTabPage.TabIndex = 0;
            this.TemplateTabPage.Text = "TemplateTabPage";
            this.TemplateTabPage.UseVisualStyleBackColor = true;
            // 
            // TemplatePartialThresholdLabel
            // 
            this.TemplatePartialThresholdLabel.AutoSize = true;
            this.TemplatePartialThresholdLabel.Location = new System.Drawing.Point(4, 138);
            this.TemplatePartialThresholdLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TemplatePartialThresholdLabel.Name = "TemplatePartialThresholdLabel";
            this.TemplatePartialThresholdLabel.Size = new System.Drawing.Size(86, 13);
            this.TemplatePartialThresholdLabel.TabIndex = 11;
            this.TemplatePartialThresholdLabel.Text = "Partial Threshold";
            // 
            // TemplatePartialThresholdTextBox
            // 
            this.TemplatePartialThresholdTextBox.Location = new System.Drawing.Point(113, 136);
            this.TemplatePartialThresholdTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.TemplatePartialThresholdTextBox.Name = "TemplatePartialThresholdTextBox";
            this.TemplatePartialThresholdTextBox.Size = new System.Drawing.Size(407, 20);
            this.TemplatePartialThresholdTextBox.TabIndex = 10;
            // 
            // TemplateOutputEntitySlotComboBox
            // 
            this.TemplateOutputEntitySlotComboBox.FormattingEnabled = true;
            this.TemplateOutputEntitySlotComboBox.Items.AddRange(new object[] {
            "None",
            "Optional",
            "PartialMatch",
            "DirectMatch",
            "Match",
            "Wildcard",
            "DictionaryWildcard"});
            this.TemplateOutputEntitySlotComboBox.Location = new System.Drawing.Point(113, 114);
            this.TemplateOutputEntitySlotComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.TemplateOutputEntitySlotComboBox.Name = "TemplateOutputEntitySlotComboBox";
            this.TemplateOutputEntitySlotComboBox.Size = new System.Drawing.Size(407, 21);
            this.TemplateOutputEntitySlotComboBox.TabIndex = 9;
            // 
            // TemplateOutputEntitySlotLabel
            // 
            this.TemplateOutputEntitySlotLabel.AutoSize = true;
            this.TemplateOutputEntitySlotLabel.Location = new System.Drawing.Point(4, 116);
            this.TemplateOutputEntitySlotLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TemplateOutputEntitySlotLabel.Name = "TemplateOutputEntitySlotLabel";
            this.TemplateOutputEntitySlotLabel.Size = new System.Drawing.Size(89, 13);
            this.TemplateOutputEntitySlotLabel.TabIndex = 8;
            this.TemplateOutputEntitySlotLabel.Text = "Output Entity Slot";
            // 
            // TemplateIsOutputEntityCheckBox
            // 
            this.TemplateIsOutputEntityCheckBox.AutoSize = true;
            this.TemplateIsOutputEntityCheckBox.Location = new System.Drawing.Point(7, 94);
            this.TemplateIsOutputEntityCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.TemplateIsOutputEntityCheckBox.Name = "TemplateIsOutputEntityCheckBox";
            this.TemplateIsOutputEntityCheckBox.Size = new System.Drawing.Size(98, 17);
            this.TemplateIsOutputEntityCheckBox.TabIndex = 7;
            this.TemplateIsOutputEntityCheckBox.Text = "Is Output Entity";
            this.TemplateIsOutputEntityCheckBox.UseVisualStyleBackColor = true;
            // 
            // TemplateMatchStringDictionaryComboBox
            // 
            this.TemplateMatchStringDictionaryComboBox.FormattingEnabled = true;
            this.TemplateMatchStringDictionaryComboBox.Items.AddRange(new object[] {
            "None",
            "Optional",
            "PartialMatch",
            "DirectMatch",
            "Match",
            "Wildcard",
            "DictionaryWildcard"});
            this.TemplateMatchStringDictionaryComboBox.Location = new System.Drawing.Point(113, 29);
            this.TemplateMatchStringDictionaryComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.TemplateMatchStringDictionaryComboBox.Name = "TemplateMatchStringDictionaryComboBox";
            this.TemplateMatchStringDictionaryComboBox.Size = new System.Drawing.Size(407, 21);
            this.TemplateMatchStringDictionaryComboBox.TabIndex = 6;
            // 
            // TemplateSourceStringLabel
            // 
            this.TemplateSourceStringLabel.AutoSize = true;
            this.TemplateSourceStringLabel.Location = new System.Drawing.Point(4, 54);
            this.TemplateSourceStringLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TemplateSourceStringLabel.Name = "TemplateSourceStringLabel";
            this.TemplateSourceStringLabel.Size = new System.Drawing.Size(71, 13);
            this.TemplateSourceStringLabel.TabIndex = 5;
            this.TemplateSourceStringLabel.Text = "Source String";
            // 
            // TemplateSourceStringTextBox
            // 
            this.TemplateSourceStringTextBox.Location = new System.Drawing.Point(113, 52);
            this.TemplateSourceStringTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.TemplateSourceStringTextBox.Name = "TemplateSourceStringTextBox";
            this.TemplateSourceStringTextBox.ReadOnly = true;
            this.TemplateSourceStringTextBox.Size = new System.Drawing.Size(407, 20);
            this.TemplateSourceStringTextBox.TabIndex = 4;
            // 
            // TemplateMatchStringTextBox
            // 
            this.TemplateMatchStringTextBox.Location = new System.Drawing.Point(113, 29);
            this.TemplateMatchStringTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.TemplateMatchStringTextBox.Name = "TemplateMatchStringTextBox";
            this.TemplateMatchStringTextBox.Size = new System.Drawing.Size(411, 20);
            this.TemplateMatchStringTextBox.TabIndex = 3;
            // 
            // TemplateMatchStringLabel
            // 
            this.TemplateMatchStringLabel.AutoSize = true;
            this.TemplateMatchStringLabel.Location = new System.Drawing.Point(4, 31);
            this.TemplateMatchStringLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TemplateMatchStringLabel.Name = "TemplateMatchStringLabel";
            this.TemplateMatchStringLabel.Size = new System.Drawing.Size(67, 13);
            this.TemplateMatchStringLabel.TabIndex = 2;
            this.TemplateMatchStringLabel.Text = "Match String";
            // 
            // TemplateTypeComboBox
            // 
            this.TemplateTypeComboBox.FormattingEnabled = true;
            this.TemplateTypeComboBox.Items.AddRange(new object[] {
            "None",
            "Optional",
            "Partial Match",
            "Direct Match",
            "Match",
            "Wildcard",
            "Dictionary Wildcard",
            "Special Wildcard"});
            this.TemplateTypeComboBox.Location = new System.Drawing.Point(113, 6);
            this.TemplateTypeComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.TemplateTypeComboBox.Name = "TemplateTypeComboBox";
            this.TemplateTypeComboBox.Size = new System.Drawing.Size(407, 21);
            this.TemplateTypeComboBox.TabIndex = 1;
            // 
            // TemplateTypeLabel
            // 
            this.TemplateTypeLabel.AutoSize = true;
            this.TemplateTypeLabel.Location = new System.Drawing.Point(4, 8);
            this.TemplateTypeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TemplateTypeLabel.Name = "TemplateTypeLabel";
            this.TemplateTypeLabel.Size = new System.Drawing.Size(31, 13);
            this.TemplateTypeLabel.TabIndex = 0;
            this.TemplateTypeLabel.Text = "Type";
            // 
            // GUIDTextBox
            // 
            this.GUIDTextBox.Location = new System.Drawing.Point(94, 354);
            this.GUIDTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.GUIDTextBox.Name = "GUIDTextBox";
            this.GUIDTextBox.ReadOnly = true;
            this.GUIDTextBox.Size = new System.Drawing.Size(446, 20);
            this.GUIDTextBox.TabIndex = 4;
            // 
            // LanguageComboBox
            // 
            this.LanguageComboBox.FormattingEnabled = true;
            this.LanguageComboBox.Items.AddRange(new object[] {
            "English"});
            this.LanguageComboBox.Location = new System.Drawing.Point(94, 374);
            this.LanguageComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.LanguageComboBox.Name = "LanguageComboBox";
            this.LanguageComboBox.Size = new System.Drawing.Size(446, 21);
            this.LanguageComboBox.TabIndex = 5;
            // 
            // GUIDLabel
            // 
            this.GUIDLabel.AutoSize = true;
            this.GUIDLabel.Location = new System.Drawing.Point(10, 356);
            this.GUIDLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.GUIDLabel.Name = "GUIDLabel";
            this.GUIDLabel.Size = new System.Drawing.Size(34, 13);
            this.GUIDLabel.TabIndex = 6;
            this.GUIDLabel.Text = "GUID";
            // 
            // LanguageLabel
            // 
            this.LanguageLabel.AutoSize = true;
            this.LanguageLabel.Location = new System.Drawing.Point(10, 376);
            this.LanguageLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LanguageLabel.Name = "LanguageLabel";
            this.LanguageLabel.Size = new System.Drawing.Size(55, 13);
            this.LanguageLabel.TabIndex = 7;
            this.LanguageLabel.Text = "Language";
            // 
            // ShapeEditorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 406);
            this.Controls.Add(this.LanguageLabel);
            this.Controls.Add(this.GUIDLabel);
            this.Controls.Add(this.LanguageComboBox);
            this.Controls.Add(this.GUIDTextBox);
            this.Controls.Add(this.EntityTabControl);
            this.Controls.Add(this.EntityCountLabel);
            this.Controls.Add(this.ShapeLabel);
            this.Controls.Add(this.ShapeTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ShapeEditorWindow";
            this.Text = "Shape Editor";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ShapeEditorWindow_FormClosed);
            this.Load += new System.EventHandler(this.ShapeEditorWindow_Load);
            this.EntityTabControl.ResumeLayout(false);
            this.TemplateTabPage.ResumeLayout(false);
            this.TemplateTabPage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ShapeTextBox;
        private System.Windows.Forms.Label ShapeLabel;
        private System.Windows.Forms.Label EntityCountLabel;
        private System.Windows.Forms.TabControl EntityTabControl;
        private System.Windows.Forms.TabPage TemplateTabPage;
        private System.Windows.Forms.TextBox GUIDTextBox;
        private System.Windows.Forms.ComboBox LanguageComboBox;
        private System.Windows.Forms.Label GUIDLabel;
        private System.Windows.Forms.Label LanguageLabel;
        private System.Windows.Forms.ComboBox TemplateTypeComboBox;
        private System.Windows.Forms.Label TemplateTypeLabel;
        private System.Windows.Forms.Label TemplateSourceStringLabel;
        private System.Windows.Forms.TextBox TemplateSourceStringTextBox;
        private System.Windows.Forms.TextBox TemplateMatchStringTextBox;
        private System.Windows.Forms.Label TemplateMatchStringLabel;
        private System.Windows.Forms.CheckBox TemplateIsOutputEntityCheckBox;
        private System.Windows.Forms.ComboBox TemplateMatchStringDictionaryComboBox;
        private System.Windows.Forms.ComboBox TemplateOutputEntitySlotComboBox;
        private System.Windows.Forms.Label TemplateOutputEntitySlotLabel;
        private System.Windows.Forms.Label TemplatePartialThresholdLabel;
        private System.Windows.Forms.TextBox TemplatePartialThresholdTextBox;
    }
}