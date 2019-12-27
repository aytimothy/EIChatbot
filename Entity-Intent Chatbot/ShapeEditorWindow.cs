using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using aytimothy.EIChatbot.Data;

namespace aytimothy.EIChatbot.Editor
{
    public partial class ShapeEditorWindow : Form {
        public IntentEditorWindow ParentWindow;
        public EventHandler<OnShapeEndEdit> OnEndEdit;
        public Shape Data;
        private bool modified;

        private void ShapeEditorWindow_Load(object sender, EventArgs e) {
            modified = true;
        }

        public ShapeEditorWindow(IntentEditorWindow parent) {
            InitializeComponent();
            ParentWindow = parent;
            Data = new Shape("");
            Data.GUID = EditorUtils.ByteArrayToHexString(EditorUtils.GenerateNextGUID());
        }

        public ShapeEditorWindow(IntentEditorWindow parent, Shape existingData) {
            InitializeComponent();
            ParentWindow = parent;
            Data = existingData;
        }

        private void ShapeEditorWindow_FormClosed(object sender, FormClosedEventArgs e) {
            OnShapeEndEdit result = new OnShapeEndEdit() {
                Data = Data,
                DialogResult = (modified) ? DialogResult.OK : DialogResult.Cancel
            };
            OnEndEdit.Invoke(this, result);
        }
    }

    public class OnShapeEndEdit : EventArgs {
        public Shape Data;
        public DialogResult DialogResult;
    }
}
