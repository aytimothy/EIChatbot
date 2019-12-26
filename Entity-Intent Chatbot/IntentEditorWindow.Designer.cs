namespace aytimothy.EIChatbot.Editor
{
    partial class IntentEditorWindow
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
            this.label1 = new System.Windows.Forms.Label();
            this.DomainTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.GUIDTextBox = new System.Windows.Forms.TextBox();
            this.ShapeView = new System.Windows.Forms.DataGridView();
            this.GUID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Shape = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddShapeButton = new System.Windows.Forms.Button();
            this.EditShapeButton = new System.Windows.Forms.Button();
            this.RemoveShapeButton = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.IDTextBox = new System.Windows.Forms.TextBox();
            this.IDLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ShapeView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Domain";
            // 
            // DomainTextBox
            // 
            this.DomainTextBox.Location = new System.Drawing.Point(124, 9);
            this.DomainTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DomainTextBox.Name = "DomainTextBox";
            this.DomainTextBox.Size = new System.Drawing.Size(750, 26);
            this.DomainTextBox.TabIndex = 1;
            this.DomainTextBox.TextChanged += new System.EventHandler(this.DomainTextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 92);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "GUID";
            // 
            // GUIDTextBox
            // 
            this.GUIDTextBox.Location = new System.Drawing.Point(124, 88);
            this.GUIDTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GUIDTextBox.Name = "GUIDTextBox";
            this.GUIDTextBox.ReadOnly = true;
            this.GUIDTextBox.Size = new System.Drawing.Size(750, 26);
            this.GUIDTextBox.TabIndex = 3;
            // 
            // ShapeView
            // 
            this.ShapeView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ShapeView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GUID,
            this.Shape});
            this.ShapeView.Location = new System.Drawing.Point(16, 128);
            this.ShapeView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ShapeView.Name = "ShapeView";
            this.ShapeView.Size = new System.Drawing.Size(858, 231);
            this.ShapeView.TabIndex = 4;
            // 
            // GUID
            // 
            this.GUID.HeaderText = "GUID";
            this.GUID.Name = "GUID";
            // 
            // Shape
            // 
            this.Shape.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Shape.HeaderText = "Shape";
            this.Shape.Name = "Shape";
            // 
            // AddShapeButton
            // 
            this.AddShapeButton.Location = new System.Drawing.Point(18, 368);
            this.AddShapeButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AddShapeButton.Name = "AddShapeButton";
            this.AddShapeButton.Size = new System.Drawing.Size(112, 35);
            this.AddShapeButton.TabIndex = 5;
            this.AddShapeButton.Text = "Add";
            this.AddShapeButton.UseVisualStyleBackColor = true;
            this.AddShapeButton.Click += new System.EventHandler(this.AddShapeButton_Click);
            // 
            // EditShapeButton
            // 
            this.EditShapeButton.Location = new System.Drawing.Point(140, 368);
            this.EditShapeButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.EditShapeButton.Name = "EditShapeButton";
            this.EditShapeButton.Size = new System.Drawing.Size(112, 35);
            this.EditShapeButton.TabIndex = 6;
            this.EditShapeButton.Text = "Edit";
            this.EditShapeButton.UseVisualStyleBackColor = true;
            this.EditShapeButton.Click += new System.EventHandler(this.EditShapeButton_Click);
            // 
            // RemoveShapeButton
            // 
            this.RemoveShapeButton.Location = new System.Drawing.Point(261, 368);
            this.RemoveShapeButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RemoveShapeButton.Name = "RemoveShapeButton";
            this.RemoveShapeButton.Size = new System.Drawing.Size(112, 35);
            this.RemoveShapeButton.TabIndex = 7;
            this.RemoveShapeButton.Text = "Remove";
            this.RemoveShapeButton.UseVisualStyleBackColor = true;
            this.RemoveShapeButton.Click += new System.EventHandler(this.RemoveShapeButton_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(18, 412);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(856, 231);
            this.dataGridView2.TabIndex = 8;
            // 
            // IDTextBox
            // 
            this.IDTextBox.Location = new System.Drawing.Point(124, 49);
            this.IDTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.IDTextBox.Name = "IDTextBox";
            this.IDTextBox.Size = new System.Drawing.Size(750, 26);
            this.IDTextBox.TabIndex = 10;
            this.IDTextBox.TextChanged += new System.EventHandler(this.IDTextBox_TextChanged);
            // 
            // IDLabel
            // 
            this.IDLabel.AutoSize = true;
            this.IDLabel.Location = new System.Drawing.Point(18, 54);
            this.IDLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.IDLabel.Name = "IDLabel";
            this.IDLabel.Size = new System.Drawing.Size(26, 20);
            this.IDLabel.TabIndex = 9;
            this.IDLabel.Text = "ID";
            // 
            // IntentEditorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 662);
            this.Controls.Add(this.IDTextBox);
            this.Controls.Add(this.IDLabel);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.RemoveShapeButton);
            this.Controls.Add(this.EditShapeButton);
            this.Controls.Add(this.AddShapeButton);
            this.Controls.Add(this.ShapeView);
            this.Controls.Add(this.GUIDTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DomainTextBox);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "IntentEditorWindow";
            this.Text = "Intent Editor";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.IntentEditorWindow_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.ShapeView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox DomainTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox GUIDTextBox;
        private System.Windows.Forms.DataGridView ShapeView;
        private System.Windows.Forms.Button AddShapeButton;
        private System.Windows.Forms.Button EditShapeButton;
        private System.Windows.Forms.Button RemoveShapeButton;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TextBox IDTextBox;
        private System.Windows.Forms.Label IDLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn GUID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Shape;
    }
}