using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using aytimothy.EIChatbot.Data;

namespace aytimothy.EIChatbot.Editor {
    public partial class OutputEntityEditorWindow : Form {
        public IntentEditorWindow ParentWindow;
        public EventHandler<OnOutputEntityEndEdit> OnEndEdit;
        public OutputEntity Data;
        private bool modified;

        public OutputEntityEditorWindow(IntentEditorWindow parent) {
            InitializeComponent();
            ParentWindow = parent;
            Data = new OutputEntity();
            Data.GUID = EditorUtils.ByteArrayToHexString(EditorUtils.GenerateNextGUID());
        }

        public OutputEntityEditorWindow (IntentEditorWindow parent, OutputEntity existingData) {
            InitializeComponent();
            ParentWindow = parent;
            Data = existingData;
        }

        private void OutputEntityEditorWindow_Load(object sender, EventArgs e) {
            FillTextBox();

            void FillTextBox() {
                NameTextBox.Text = Data.Name;
                GUIDTextBox.Text = Data.GUID;
                modified = false;
            }
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e) {
            modified = true;
            Data.Name = NameTextBox.Text;
        }

        private void GUIDTextBox_TextChanged(object sender, EventArgs e) {
            modified = true;
            Data.GUID = GUIDTextBox.Text;
        }

        private void OutputEntityEditorWindow_FormClosed(object sender, FormClosedEventArgs e) {
            OnOutputEntityEndEdit result = new OnOutputEntityEndEdit() {
                Data = Data,
                DialogResult = (modified) ? DialogResult.OK : DialogResult.Cancel
            };
            OnEndEdit.Invoke(this, result);
        }
    }

    public class OnOutputEntityEndEdit : EventArgs {
        public OutputEntity Data;
        public DialogResult DialogResult;
    }
}
