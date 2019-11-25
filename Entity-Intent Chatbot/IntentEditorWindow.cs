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

        public IntentEditorWindow(EditorWindow parent) {
            InitializeComponent();
            ParentWindow = parent;
        }

        public IntentEditorWindow(EditorWindow parent, Intent existingData) {
            InitializeComponent();
            ParentWindow = parent;
            Data = existingData;

            throw new NotImplementedException();
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

            throw new NotImplementedException();
        }

        private void EditShapeButton_Click(object sender, EventArgs e) {

        }

        private void RemoveShapeButton_Click(object sender, EventArgs e) {
            throw new NotImplementedException();
        }

        private void DomainTextBox_TextChanged(object sender, EventArgs e) {

        }
    }

    public class IntentEditorWindowOnEndEditEvent : EventArgs {
        public Intent NewData;
        public DialogResult DialogResult;
    }
}
