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

            GUIDTextBox.Text = Data.GUID;
            DomainTextBox.Text = Data.IntentDomain;
            IDTextBox.Text = Data.IntentID;
        }

        private void AddShapeButton_Click(object sender, EventArgs e) {
            ShapeEditorWindow shapeEditorWindow = new ShapeEditorWindow(this);
            shapeEditorWindow.Show();
            shapeEditorWindow.OnEndEdit += Shape_OnEndEdit;
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
        }

        private void EditShapeButton_Click(object sender, EventArgs e) {
            if (ShapeView.SelectedRows.Count <= 0) {
                MessageBox.Show("Please select a row to edit...", "Error!");
                return;
            }

            DataRow row = ((DataRowView)ShapeView.SelectedRows[0].DataBoundItem).Row;
            string guid = (string)row.ItemArray[0];

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
                MessageBox.Show("Could not find intent with GUID: \"" + guid.ToUpper() + "\".", "Error!");
            }
        }

        private void RemoveShapeButton_Click(object sender, EventArgs e) {
            modified = true;

            if (ShapeView.SelectedRows.Count <= 0) {
                MessageBox.Show("Please select a row to edit...", "Error!");
                return;
            }

            DataRow row = ((DataRowView)ShapeView.SelectedRows[0].DataBoundItem).Row;
            string guid = (string)row.ItemArray[0];

            bool found = false;
            int index = -1;
            for (int i = 0; i < Data.Shapes.Length - 1; i++) {
                if (Data.Shapes[i].GUID.ToUpper() == guid.ToUpper()) {
                    found = true;
                    index = i;
                }
                if (found)
                    Data.Shapes[i - 1] = Data.Shapes[i];
            }

            if (!found)
                MessageBox.Show("Could not find shape with GUID: \"" + guid.ToUpper() + "\".", "Error!");
            if (found)
                Array.Resize<Shape>(ref Data.Shapes, Data.Shapes.Length - 1);
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
    }

    public class IntentEditorWindowOnEndEditEvent : EventArgs {
        public Intent Data;
        public DialogResult DialogResult;
    }
}
