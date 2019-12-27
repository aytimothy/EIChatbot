using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;
using aytimothy.EIChatbot.Data;

namespace aytimothy.EIChatbot.Editor {
    public partial class IntentEditorWindow : Form {
        public EditorWindow ParentWindow;
        public EventHandler<IntentEditorWindowOnEndEditEvent> OnCompleteEvent;
        public Intent Data;
        public List<ShapeEditorWindow> Editors = new List<ShapeEditorWindow>();
        public List<OutputEntityEditorWindow> Editors2 = new List<OutputEntityEditorWindow>();
        public bool modified;

        public IntentEditorWindow(EditorWindow parent) {
            InitializeComponent();
            ParentWindow = parent;
            Data = new Intent("", "");
            Data.GUID = EditorUtils.ByteArrayToHexString(EditorUtils.GenerateNextGUID());

            UpdateFields();
        }

        public IntentEditorWindow(EditorWindow parent, Intent existingData) {
            InitializeComponent();
            ParentWindow = parent;
            Data = existingData;

            UpdateFields();
        }

        private void UpdateFields() {
            ShapeView.Rows.Clear();
            foreach (Shape shape in Data.Shapes)
                ShapeView.Rows.Add(new string[] {shape.GUID, shape.ShapeString});
            OutputEntityView.Rows.Clear();
            foreach (OutputEntity outputEntity in Data.Outputs)
                OutputEntityView.Rows.Add(new string[] {outputEntity.GUID, outputEntity.Name});

            GUIDTextBox.Text = Data.GUID;
            DomainTextBox.Text = Data.IntentDomain;
            IDTextBox.Text = Data.IntentID;
        }

        private void AddShapeButton_Click(object sender, EventArgs e) {
            ShapeEditorWindow shapeEditorWindow = new ShapeEditorWindow(this);
            shapeEditorWindow.OnEndEdit += Shape_OnEndEdit;
            shapeEditorWindow.Show();
            Editors.Add(shapeEditorWindow);
        }

        private void Shape_OnEndEdit (object sender, OnShapeEndEdit e) {
            ShapeEditorWindow _sender = (ShapeEditorWindow) sender;
            Editors.Remove(_sender);

            if (e.DialogResult != DialogResult.OK)
                return;

            modified = true;
            bool exists = false;
            for (int i = 0; i < Data.Shapes.Length; i++)
                if (Data.Shapes[i].GUID.ToUpper() == e.Data.GUID.ToUpper()) {
                    exists = true;
                    Data.Shapes[i] = e.Data;
                }

            if (!exists) {
                Array.Resize<Shape>(ref Data.Shapes, Data.Shapes.Length + 1);
                Data.Shapes[Data.Shapes.Length - 1] = e.Data;
            }

            UpdateFields();
        }

        private void EditShapeButton_Click(object sender, EventArgs e) {
            string guid = (string)ShapeView.Rows[ShapeView.CurrentCell.RowIndex].Cells[0].Value;

            bool found = false;
            foreach (Shape shape in Data.Shapes)
                if (shape.GUID.ToUpper() == guid.ToUpper()) {
                    ShapeEditorWindow shapeEditor = new ShapeEditorWindow(this, shape);
                    shapeEditor.OnEndEdit += Shape_OnEndEdit;
                    Editors.Add(shapeEditor);
                    shapeEditor.Show();
                    found = true;
                    break;
                }

            if (!found) {
                MessageBox.Show("Could not find shape with GUID: \"" + guid.ToUpper() + "\".", "Error!");
            }
        }

        private void RemoveShapeButton_Click(object sender, EventArgs e) {
            string guid = (string)ShapeView.Rows[ShapeView.CurrentCell.RowIndex].Cells[0].Value;

            bool found = false;
            int index = -1;
            for (int i = 0; i < Data.Shapes.Length; i++) {
                if (Data.Shapes[i].GUID.ToUpper() == guid.ToUpper()) {
                    found = true;
                    index = i;
                    continue;
                }
                if (found)
                    Data.Shapes[i - 1] = Data.Shapes[i];
            }

            if (!found)
                MessageBox.Show("Could not find shape with GUID: \"" + guid.ToUpper() + "\".", "Error!");
            if (found)
                Array.Resize<Shape>(ref Data.Shapes, Data.Shapes.Length - 1);

            UpdateFields();
        }

        private void DomainTextBox_TextChanged(object sender, EventArgs e) {
            modified = true;

            Data.IntentDomain = DomainTextBox.Text;
        }

        private void IDTextBox_TextChanged(object sender, EventArgs e) {
            modified = true;

            Data.IntentID = IDTextBox.Text;
        }

        private void IntentEditorWindow_FormClosed(object sender, FormClosedEventArgs e) {
            foreach (ShapeEditorWindow Editor in Editors)
                Editor.Close();
            foreach (OutputEntityEditorWindow Editor in Editors2)
                Editor.Close();

            if (modified)
                OnCompleteEvent.Invoke(this, new IntentEditorWindowOnEndEditEvent() {
                    Data = Data,
                    DialogResult = DialogResult.OK
                });
            if (!modified)
                OnCompleteEvent.Invoke(this, new IntentEditorWindowOnEndEditEvent() {
                    Data = Data,
                    DialogResult = DialogResult.Cancel
                });
        }

        private void AddOutputButton_Click(object sender, EventArgs e) {
            OutputEntityEditorWindow outputEntityEditorWindow = new OutputEntityEditorWindow(this);
            outputEntityEditorWindow.Show();
            outputEntityEditorWindow.OnEndEdit += Output_OnEndEdit;
            Editors2.Add(outputEntityEditorWindow);
        }

        public void Output_OnEndEdit(object sender, OnOutputEntityEndEdit e) {
            OutputEntityEditorWindow _sender = (OutputEntityEditorWindow)sender;
            Editors2.Remove(_sender);

            if (e.DialogResult != DialogResult.OK)
                return;

            modified = true;
            bool exists = false;
            for (int i = 0; i < Data.Outputs.Length; i++)
                if (Data.Outputs[i].GUID.ToUpper() == e.Data.GUID.ToUpper()) {
                    exists = true;
                    Data.Outputs[i] = e.Data;
                }

            if (!exists) {
                Array.Resize<OutputEntity>(ref Data.Outputs, Data.Outputs.Length + 1);
                Data.Outputs[Data.Outputs.Length - 1] = e.Data;
            }

            UpdateFields();
        }

        private void EditOutputButton_Click(object sender, EventArgs e) {
            string guid = (string)OutputEntityView.Rows[OutputEntityView.CurrentCell.RowIndex].Cells[0].Value;

            bool found = false;
            foreach (OutputEntity output in Data.Outputs)
                if (output.GUID.ToUpper() == guid.ToUpper()) {
                    OutputEntityEditorWindow outputEditor = new OutputEntityEditorWindow(this, output);
                    outputEditor.OnEndEdit += Output_OnEndEdit;
                    Editors2.Add(outputEditor);
                    outputEditor.Show();
                    found = true;
                    break;
                }

            if (!found) {
                MessageBox.Show("Could not find output with GUID: \"" + guid.ToUpper() + "\".", "Error!");
            }
        }

        private void RemoveOutputButton_Click(object sender, EventArgs e) {
            string guid = (string)OutputEntityView.Rows[OutputEntityView.CurrentCell.RowIndex].Cells[0].Value;

            bool found = false;
            int index = -1;
            for (int i = 0; i < Data.Outputs.Length; i++) {
                if (Data.Outputs[i].GUID.ToUpper() == guid.ToUpper()) {
                    found = true;
                    index = i;
                    continue;
                }
                if (found)
                    Data.Outputs[i - 1] = Data.Outputs[i];
            }

            if (!found)
                MessageBox.Show("Could not find output entity with GUID: \"" + guid.ToUpper() + "\".", "Error!");
            if (found)
                Array.Resize<OutputEntity>(ref Data.Outputs, Data.Outputs.Length - 1);

            UpdateFields();
        }
    }

    public class IntentEditorWindowOnEndEditEvent : EventArgs {
        public Intent Data;
        public DialogResult DialogResult;
    }
}
