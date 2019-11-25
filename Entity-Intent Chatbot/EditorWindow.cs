using aytimothy.EIChatbot.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace aytimothy.EIChatbot.Editor
{
    public partial class EditorWindow : Form {
        public MainWindow RootWindow;
        public string FilePath;
        public string FileType;

        public Knowledgebase Data;

        private List<DictionaryEditorWindow> dictionaryEditors = new List<DictionaryEditorWindow>();
        private List<IntentEditorWindow> intentEditors = new List<IntentEditorWindow>();

        public EditorWindow(MainWindow rootWindow) {
            RootWindow = rootWindow;
            InitializeComponent();
        }

        public void CreateFile(string filePath, string fileType) {
            try {
                FileType = fileType;
                FilePath = filePath;
                Data = new Knowledgebase();

                if (File.Exists(filePath))
                    File.Delete(filePath);

                switch (fileType) {
                    case "BIN":
                        BinaryFormatter binaryFormatter = new BinaryFormatter();
                        FileStream binaryFileStream = File.Create(filePath);
                        binaryFormatter.Serialize(binaryFileStream, Data);
                        binaryFileStream.Close();
                        break;
                    case "JSON":
                        string jsonString = JsonConvert.SerializeObject(Data);
                        File.WriteAllText(filePath, jsonString);
                        break;
                    default:
                        FileType = "JSON";
                        goto case "JSON";
                }

                UpdateTitle();
            }
            catch (Exception exception) {
                FileType = "";
                FilePath = "";
                UpdateTitle();
            }
        }

        public void OpenFile(string filePath) {
            if (!File.Exists(filePath)) {
                MessageBox.Show("Error!", "The specified file does not exist. :(");
                return;
            }

            bool recognised = false;
            string[] extensionSplitString = filePath.Split('.');
            string extensionString = extensionSplitString[extensionSplitString.Length - 1];
            if (extensionString.ToUpper() == "JSON") {
                recognised = true;
                FileType = "JSON";

                string jsonString = File.ReadAllText(filePath);
                Knowledgebase fileData = JsonConvert.DeserializeObject<Knowledgebase>(jsonString);
                Data = fileData;
            }
            if (extensionString.ToUpper() == "BIN" || extensionString.ToUpper() == "EIC") {
                recognised = true;
                FileType = "BIN";

                FileStream binaryFileStream = File.Open(filePath, FileMode.Open);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                Object binaryData = binaryFormatter.Deserialize(binaryFileStream);
                Data = (Knowledgebase) binaryData;
            }
            if (recognised) {
                FilePath = filePath;
            }
            if (!recognised) {
                FileType = "";
                FilePath = "";
            }

            UpdateTitle();
        }

        private void EditorWindow_Load(object sender, EventArgs e) {
            UpdateTitle();
        }

        private void UpdateTitle() {
            string pathString = (String.IsNullOrEmpty(FilePath)) ? "**NO FILE LOADED**" : "(" + FilePath + ")";
            Text = "Chatbot Editor | " + pathString;
        }

        private void EditorWindow_FormClosing(object sender, FormClosingEventArgs e) {
            
        }

        private void EditorWindow_FormClosed(object sender, FormClosedEventArgs e) {

        }

        private void CreateDictionaryButton_Click(object sender, EventArgs e) {
            DictionaryEditorWindow dictionaryEditorWindow = new DictionaryEditorWindow(this);
            dictionaryEditorWindow.Show();
            dictionaryEditors.Add(dictionaryEditorWindow);
            dictionaryEditorWindow.OnCompleteEvent += OnDictionaryEndEdit;
        }

        private void OnDictionaryEndEdit(object sender, DictionaryEditorWindowEndEditEvent e) {
            DictionaryEditorWindow _sender = (DictionaryEditorWindow)sender;
            dictionaryEditors.Remove(_sender);

            throw new NotImplementedException();
        }

        private void EditDictionaryButton_Click(object sender, EventArgs e) {

        }

        private void RemoveDictionaryButton_Click(object sender, EventArgs e) {

        }

        private void AddIntentButton_Click(object sender, EventArgs e) {
            IntentEditorWindow intentEditorWindow = new IntentEditorWindow(this);
            intentEditorWindow.Show();
            intentEditors.Add(intentEditorWindow);
            intentEditorWindow.OnCompleteEvent += OnIntentEndEdit;
        }

        private void OnIntentEndEdit(object sender, IntentEditorWindowOnEndEditEvent e) {
            IntentEditorWindow _sender = (IntentEditorWindow) sender;
            intentEditors.Remove(_sender);

            throw new NotImplementedException();
        }

        private void EditIntentButton_Click(object sender, EventArgs e) {

        }

        private void RemoveIntentButton_Click(object sender, EventArgs e) {

        }
    }
}
