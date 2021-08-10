namespace aytimothy.EIChatbot.Editor
{
    partial class EditorWindow
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.metadataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.DictionaryView = new System.Windows.Forms.DataGridView();
            this.GUID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DictionaryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DictionarySize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DictionaryLabel = new System.Windows.Forms.Label();
            this.CreateDictionaryButton = new System.Windows.Forms.Button();
            this.EditDictionaryButton = new System.Windows.Forms.Button();
            this.RemoveDictionaryButton = new System.Windows.Forms.Button();
            this.IntentLabel = new System.Windows.Forms.Label();
            this.IntentView = new System.Windows.Forms.DataGridView();
            this.IntentGUID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IntentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IntentDomain = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IntentSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddIntentButton = new System.Windows.Forms.Button();
            this.EditIntentButton = new System.Windows.Forms.Button();
            this.RemoveIntentButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DictionaryView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IntentView)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 439);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(588, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editorToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(588, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(192, 6);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // editorToolStripMenuItem
            // 
            this.editorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.metadataToolStripMenuItem});
            this.editorToolStripMenuItem.Name = "editorToolStripMenuItem";
            this.editorToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editorToolStripMenuItem.Text = "Edit";
            // 
            // metadataToolStripMenuItem
            // 
            this.metadataToolStripMenuItem.Name = "metadataToolStripMenuItem";
            this.metadataToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.metadataToolStripMenuItem.Text = "Metadata";
            this.metadataToolStripMenuItem.Click += new System.EventHandler(this.metadataToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.helpToolStripMenuItem1});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.helpToolStripMenuItem1.Text = "Help";
            this.helpToolStripMenuItem1.Click += new System.EventHandler(this.helpToolStripMenuItem1_Click);
            // 
            // DictionaryView
            // 
            this.DictionaryView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DictionaryView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GUID,
            this.DictionaryName,
            this.DictionarySize});
            this.DictionaryView.Location = new System.Drawing.Point(12, 40);
            this.DictionaryView.Name = "DictionaryView";
            this.DictionaryView.Size = new System.Drawing.Size(564, 150);
            this.DictionaryView.TabIndex = 2;
            // 
            // GUID
            // 
            this.GUID.HeaderText = "GUID";
            this.GUID.Name = "GUID";
            // 
            // DictionaryName
            // 
            this.DictionaryName.HeaderText = "Name";
            this.DictionaryName.Name = "DictionaryName";
            // 
            // DictionarySize
            // 
            this.DictionarySize.HeaderText = "Count";
            this.DictionarySize.Name = "DictionarySize";
            // 
            // DictionaryLabel
            // 
            this.DictionaryLabel.AutoSize = true;
            this.DictionaryLabel.Location = new System.Drawing.Point(12, 24);
            this.DictionaryLabel.Name = "DictionaryLabel";
            this.DictionaryLabel.Size = new System.Drawing.Size(62, 13);
            this.DictionaryLabel.TabIndex = 3;
            this.DictionaryLabel.Text = "Dictionaries";
            // 
            // CreateDictionaryButton
            // 
            this.CreateDictionaryButton.Location = new System.Drawing.Point(12, 196);
            this.CreateDictionaryButton.Name = "CreateDictionaryButton";
            this.CreateDictionaryButton.Size = new System.Drawing.Size(75, 23);
            this.CreateDictionaryButton.TabIndex = 4;
            this.CreateDictionaryButton.Text = "Add";
            this.CreateDictionaryButton.UseVisualStyleBackColor = true;
            this.CreateDictionaryButton.Click += new System.EventHandler(this.CreateDictionaryButton_Click);
            // 
            // EditDictionaryButton
            // 
            this.EditDictionaryButton.Location = new System.Drawing.Point(93, 196);
            this.EditDictionaryButton.Name = "EditDictionaryButton";
            this.EditDictionaryButton.Size = new System.Drawing.Size(75, 23);
            this.EditDictionaryButton.TabIndex = 5;
            this.EditDictionaryButton.Text = "Edit";
            this.EditDictionaryButton.UseVisualStyleBackColor = true;
            this.EditDictionaryButton.Click += new System.EventHandler(this.EditDictionaryButton_Click);
            // 
            // RemoveDictionaryButton
            // 
            this.RemoveDictionaryButton.Location = new System.Drawing.Point(174, 196);
            this.RemoveDictionaryButton.Name = "RemoveDictionaryButton";
            this.RemoveDictionaryButton.Size = new System.Drawing.Size(75, 23);
            this.RemoveDictionaryButton.TabIndex = 6;
            this.RemoveDictionaryButton.Text = "Remove";
            this.RemoveDictionaryButton.UseVisualStyleBackColor = true;
            this.RemoveDictionaryButton.Click += new System.EventHandler(this.RemoveDictionaryButton_Click);
            // 
            // IntentLabel
            // 
            this.IntentLabel.AutoSize = true;
            this.IntentLabel.Location = new System.Drawing.Point(12, 234);
            this.IntentLabel.Name = "IntentLabel";
            this.IntentLabel.Size = new System.Drawing.Size(39, 13);
            this.IntentLabel.TabIndex = 7;
            this.IntentLabel.Text = "Intents";
            // 
            // IntentView
            // 
            this.IntentView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.IntentView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IntentGUID,
            this.IntentName,
            this.IntentDomain,
            this.IntentSize});
            this.IntentView.Location = new System.Drawing.Point(12, 250);
            this.IntentView.Name = "IntentView";
            this.IntentView.Size = new System.Drawing.Size(564, 150);
            this.IntentView.TabIndex = 8;
            // 
            // IntentGUID
            // 
            this.IntentGUID.HeaderText = "GUID";
            this.IntentGUID.Name = "IntentGUID";
            // 
            // IntentName
            // 
            this.IntentName.HeaderText = "Name";
            this.IntentName.Name = "IntentName";
            // 
            // IntentDomain
            // 
            this.IntentDomain.HeaderText = "Domain";
            this.IntentDomain.Name = "IntentDomain";
            // 
            // IntentSize
            // 
            this.IntentSize.HeaderText = "Size";
            this.IntentSize.Name = "IntentSize";
            // 
            // AddIntentButton
            // 
            this.AddIntentButton.Location = new System.Drawing.Point(12, 406);
            this.AddIntentButton.Name = "AddIntentButton";
            this.AddIntentButton.Size = new System.Drawing.Size(75, 23);
            this.AddIntentButton.TabIndex = 9;
            this.AddIntentButton.Text = "Add";
            this.AddIntentButton.UseVisualStyleBackColor = true;
            this.AddIntentButton.Click += new System.EventHandler(this.AddIntentButton_Click);
            // 
            // EditIntentButton
            // 
            this.EditIntentButton.Location = new System.Drawing.Point(93, 406);
            this.EditIntentButton.Name = "EditIntentButton";
            this.EditIntentButton.Size = new System.Drawing.Size(75, 23);
            this.EditIntentButton.TabIndex = 10;
            this.EditIntentButton.Text = "Edit";
            this.EditIntentButton.UseVisualStyleBackColor = true;
            this.EditIntentButton.Click += new System.EventHandler(this.EditIntentButton_Click);
            // 
            // RemoveIntentButton
            // 
            this.RemoveIntentButton.Location = new System.Drawing.Point(174, 406);
            this.RemoveIntentButton.Name = "RemoveIntentButton";
            this.RemoveIntentButton.Size = new System.Drawing.Size(75, 23);
            this.RemoveIntentButton.TabIndex = 11;
            this.RemoveIntentButton.Text = "Remove";
            this.RemoveIntentButton.UseVisualStyleBackColor = true;
            this.RemoveIntentButton.Click += new System.EventHandler(this.RemoveIntentButton_Click);
            // 
            // EditorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 461);
            this.Controls.Add(this.RemoveIntentButton);
            this.Controls.Add(this.EditIntentButton);
            this.Controls.Add(this.AddIntentButton);
            this.Controls.Add(this.IntentView);
            this.Controls.Add(this.IntentLabel);
            this.Controls.Add(this.RemoveDictionaryButton);
            this.Controls.Add(this.EditDictionaryButton);
            this.Controls.Add(this.CreateDictionaryButton);
            this.Controls.Add(this.DictionaryLabel);
            this.Controls.Add(this.DictionaryView);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "EditorWindow";
            this.Text = "Chatbot Editor (%FILENAME%)";
            this.Activated += new System.EventHandler(this.EditorWindow_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditorWindow_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EditorWindow_FormClosed);
            this.Load += new System.EventHandler(this.EditorWindow_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DictionaryView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IntentView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.DataGridView DictionaryView;
        private System.Windows.Forms.Label DictionaryLabel;
        private System.Windows.Forms.Button CreateDictionaryButton;
        private System.Windows.Forms.Button EditDictionaryButton;
        private System.Windows.Forms.Button RemoveDictionaryButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn GUID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DictionaryName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DictionarySize;
        private System.Windows.Forms.Label IntentLabel;
        private System.Windows.Forms.DataGridView IntentView;
        private System.Windows.Forms.DataGridViewTextBoxColumn IntentGUID;
        private System.Windows.Forms.DataGridViewTextBoxColumn IntentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn IntentDomain;
        private System.Windows.Forms.DataGridViewTextBoxColumn IntentSize;
        private System.Windows.Forms.Button AddIntentButton;
        private System.Windows.Forms.Button EditIntentButton;
        private System.Windows.Forms.Button RemoveIntentButton;
        private System.Windows.Forms.ToolStripMenuItem metadataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
    }
}