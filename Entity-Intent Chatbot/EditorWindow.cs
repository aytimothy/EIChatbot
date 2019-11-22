using System;
using System.IO;
using System.Windows.Forms;

namespace aytimothy.EIChatbot.Editor
{
    public partial class EditorWindow : Form {
        public MainWindow RootWindow;
        public string FilePath;
        public string FileType;

        public EditorWindow(MainWindow rootWindow, string filePath) {
            FilePath = filePath;
            string ext = Path.GetExtension(filePath);

            FileType = "JSON";
            if (ext.ToLower() == "eic") {
                FileType = "BIN";
            }

            try {
                if (File.Exists(filePath))
                    File.Delete(filePath);
                CreateFile(filePath);
            }
            catch {
                MessageBox.Show("Error!", "Could not create or read file!");
                RootWindow.Show();
                Close();
                return;
            }

            RootWindow = rootWindow;
            InitializeComponent();
        }

        public void CreateFile(string filePath) {
            switch (FileType) {
                case "BIN":

                    break;
                case "JSON":

                    break;
                default:
                    FileType = "JSON";
                    goto case "JSON";
            }
        }

        public void OpenFile(string filePath) {

        }

        private void EditorWindow_Load(object sender, EventArgs e) {
            
        }

        private void EditorWindow_FormClosing(object sender, FormClosingEventArgs e) {
            
        }

        private void EditorWindow_FormClosed(object sender, FormClosedEventArgs e) {

        }

        private void CreateDictionaryButton_Click(object sender, EventArgs e) {

        }

        private void EditDictionaryButton_Click(object sender, EventArgs e) {

        }

        private void RemoveDictionaryButton_Click(object sender, EventArgs e) {

        }

        private void AddIntentButton_Click(object sender, EventArgs e) {

        }

        private void EditIntentButton_Click(object sender, EventArgs e) {

        }

        private void RemoveIntentButton_Click(object sender, EventArgs e) {

        }
    }
}
