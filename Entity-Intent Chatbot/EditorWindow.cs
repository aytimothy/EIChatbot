using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using aytimothy.EIChatbot.Data;
using Newtonsoft.Json;

namespace aytimothy.EIChatbot.Editor
{
    public partial class EditorWindow : Form {
        public MainWindow RootWindow;
        public string FilePath;
        public string FileType;

        public Knowledgebase Data;

        public List<DictionaryEditorWindow> DictionaryEditors = new List<DictionaryEditorWindow>();
        public List<IntentEditorWindow> IntentEditors = new List<IntentEditorWindow>();

        public bool modified = false;
        public bool quitApplication = false;

        public EditorWindow(MainWindow rootWindow) {
            RootWindow = rootWindow;
            InitializeComponent();
        }

        public void CreateFile(string filePath) {
            string[] pathSplit = filePath.Split('.');
            if (pathSplit.Length == 1) {
                CreateFile(filePath, "BIN");
                return;
            }

            string extension = pathSplit[pathSplit.Length - 1].ToUpper();
            switch (extension) {
                case "JSON":
                    CreateFile(filePath, "JSON");
                    break;
                case "BIN":
                    CreateFile("BIN");
                    break;
                case "EIC":
                    goto case "BIN";
                default:
                    goto case "JSON";
            }
        }

        public void CreateFile(string filePath, string fileType) {
            try {
                FileType = fileType;
                FilePath = filePath;
                Data = new Knowledgebase();

                if (File.Exists(filePath))
                    File.Delete(filePath);

                switch (fileType.ToUpper()) {
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
                    case "EIC":
                        FileType = "BIN";
                        goto case "BIN";
                    default:
                        FileType = "JSON";
                        goto case "JSON";
                }

                UpdateTitle();
                UpdateDictionaries();
                UpdateIntents();
            }
            catch {
                FileType = "";
                FilePath = "";
                UpdateTitle();
                UpdateDictionaries();
                UpdateIntents();
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
            UpdateDictionaries();
            UpdateIntents();
        }

        public void SaveFile(string filePath) {
            switch (FileType) {
                case "JSON":
                    SaveJSON(filePath, Data);
                    break;
                case "BIN":
                    SaveBinary(filePath, Data);
                    break;
                case "EIC":
                    goto case "BIN";
                default:
                    goto case "JSON";
            }
        }

        public void SaveBinary(string filePath, Knowledgebase data) {
            if (File.Exists(filePath))
                File.Delete(filePath);
            
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = File.Open(filePath, FileMode.CreateNew);
            binaryFormatter.Serialize(fileStream, data);
            fileStream.Close();
        }

        public void SaveJSON(string filePath, Knowledgebase data) {
            if (File.Exists(filePath))
                File.Delete(filePath);

            string jsonString = JsonConvert.SerializeObject(data);
            File.WriteAllText(filePath, jsonString);
        }

        private void EditorWindow_Load(object sender, EventArgs e) {
            UpdateTitle();
        }

        private void UpdateTitle() {
            string pathString = (String.IsNullOrEmpty(FilePath)) ? "**NO FILE LOADED**" : "(" + FilePath + ")";
            Text = "Chatbot Editor | " + pathString;
        }

        private void UpdateDictionaries() {
            DictionaryView.Rows.Clear();

            if (Data == null)
                return;
            if (Data.Dictionaries == null)
                return;
            if (Data.Dictionaries.Count <= 0)
                return;
            foreach (Dictionary dictionary in Data.Dictionaries)
                DictionaryView.Rows.Add(dictionary.GUID, dictionary.Name, dictionary.Vocabulary.Count.ToString());
        }

        private void UpdateIntents() {
            IntentView.Rows.Clear();

            if (Data == null)
                return;
            if (Data.Intents == null)
                return;
            if (Data.Intents.Count <= 0)
                return;
            foreach (Intent intent in Data.Intents)
                IntentView.Rows.Add(intent.GUID, intent.IntentID, intent.IntentDomain, intent.Shapes.Count.ToString());
        }

        private void EditorWindow_FormClosing(object sender, FormClosingEventArgs e) {
            if (modified) {
                DialogResult saveBoxResult = MessageBox.Show("Unsaved Changes", "Would you like to save your data?", MessageBoxButtons.YesNoCancel);
                switch (saveBoxResult) {
                    case DialogResult.Yes:
                        SaveFile(FilePath);
                        break;
                    case DialogResult.No:
                        break;
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        return;
                }
            }
        }

        private void EditorWindow_FormClosed(object sender, FormClosedEventArgs e) {
            if (quitApplication)
                Application.Exit();
            if (!quitApplication)
                RootWindow.Show();
        }

        private void CreateDictionaryButton_Click(object sender, EventArgs e) {
            DictionaryEditorWindow dictionaryEditorWindow = new DictionaryEditorWindow(this);
            dictionaryEditorWindow.Show();
            DictionaryEditors.Add(dictionaryEditorWindow);
            dictionaryEditorWindow.OnCompleteEvent += OnDictionaryEndEdit;
        }

        private void OnDictionaryEndEdit(object sender, DictionaryEditorWindowEndEditEvent e) {
            DictionaryEditorWindow _sender = (DictionaryEditorWindow)sender;
            DictionaryEditors.Remove(_sender);

            bool exists = Data.Dictionaries.Any(i => i.GUID == e.Data.GUID);
            if (!exists)
                Data.Dictionaries.Add(e.Data);
            else {
                int index = Data.Dictionaries.FindIndex(i => i.GUID == e.Data.GUID);
                Data.Dictionaries[index] = e.Data;
            }

            UpdateDictionaries();
            modified = true;
        }

        private void EditDictionaryButton_Click(object sender, EventArgs e) {
            if (DictionaryView.CurrentCell == null) {
                MessageBox.Show("Please select a cell.", "Error");
                return;
            }

            string guid = (string) DictionaryView.Rows[DictionaryView.CurrentCell.RowIndex].Cells[0].Value;

            bool found = false;
            foreach (Dictionary dictionary in Data.Dictionaries)
                if (dictionary.GUID.ToUpper() == guid.ToUpper()) {
                    DictionaryEditorWindow dictionaryEditor = new DictionaryEditorWindow(this, dictionary);
                    dictionaryEditor.OnCompleteEvent += OnDictionaryEndEdit;
                    DictionaryEditors.Add(dictionaryEditor);
                    dictionaryEditor.Show();
                    found = true;
                    break;
                }

            if (!found) {
                MessageBox.Show("Could not find dictionary with GUID: \"" + guid.ToUpper() + "\".", "Error!");
            }
        }

        private void RemoveDictionaryButton_Click(object sender, EventArgs e) {
            string guid = (string)DictionaryView.Rows[DictionaryView.CurrentCell.RowIndex].Cells[0].Value;
            Dictionary dictionary = Data.Dictionaries.FirstOrDefault(d => d.GUID == guid);
            Data.Dictionaries.Remove(dictionary);

            UpdateDictionaries();
        }

        private void AddIntentButton_Click(object sender, EventArgs e) {
            IntentEditorWindow intentEditorWindow = new IntentEditorWindow(this);
            intentEditorWindow.Show();
            IntentEditors.Add(intentEditorWindow);
            intentEditorWindow.OnCompleteEvent += OnIntentEndEdit;
        }

        private void OnIntentEndEdit(object sender, IntentEditorWindowOnEndEditEvent e) {
            IntentEditorWindow _sender = (IntentEditorWindow) sender;
            IntentEditors.Remove(_sender);

            bool exists = Data.Intents.Any(i => i.GUID == e.Data.GUID);
            if (!exists)
                Data.Intents.Add(e.Data);
            else {
                int index = Data.Intents.FindIndex(i => i.GUID == e.Data.GUID);
                Data.Intents[index] = e.Data;
            }

            UpdateIntents();

            modified = true;
        }

        private void EditIntentButton_Click(object sender, EventArgs e) {
            string guid = (string)IntentView.Rows[IntentView.CurrentCell.RowIndex].Cells[0].Value;

            bool found = false;
            foreach (Intent intent in Data.Intents)
                if (intent.GUID.ToUpper() == guid.ToUpper()) {
                    IntentEditorWindow intentEditor = new IntentEditorWindow(this, intent);
                    intentEditor.OnCompleteEvent += OnIntentEndEdit;
                    IntentEditors.Add(intentEditor);
                    intentEditor.Show();
                    found = true;
                    break;
                }

            if (!found) {
                MessageBox.Show("Could not find intent with GUID: \"" + guid.ToUpper() + "\".", "Error!");
            }
        }

        private void RemoveIntentButton_Click(object sender, EventArgs e) {
            string guid = (string)IntentView.Rows[IntentView.CurrentCell.RowIndex].Cells[0].Value;
            Intent intent = Data.Intents.FirstOrDefault(i => i.GUID == guid);
            Data.Intents.Remove(intent);

            UpdateIntents();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e) {
            if (modified) {
                throw new NotImplementedException();
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Chatbot Json|*.json|Chatbot Binary|*.eic|All|*.*";
            DialogResult saveFileDialogResult = saveFileDialog.ShowDialog();
            
            if (saveFileDialogResult == DialogResult.OK)
                CreateFile(saveFileDialog.FileName);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e) {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Chatbot Json|*.json|Chatbot Binary|*.eic|All|*.*";
            DialogResult openFileDialogResult = openFileDialog.ShowDialog();

            if (openFileDialogResult == DialogResult.OK)
                OpenFile(openFileDialog.FileName);
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e) {
            Close();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e) {
            if (String.IsNullOrEmpty(FilePath)) {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Chatbot Json|*.json|Chatbot Binary|*.eic|All|*.*";
                DialogResult saveFileDialogResult = saveFileDialog.ShowDialog();

                if (saveFileDialogResult == DialogResult.OK)
                    FilePath = saveFileDialog.FileName;
            }

            if (!String.IsNullOrEmpty(FilePath)) {
                SaveFile(FilePath);
                modified = false;
                UpdateTitle();
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e) {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Chatbot Json|*.json|Chatbot Binary|*.eic|All|*.*";
            DialogResult saveFileDialogResult = saveFileDialog.ShowDialog();

            if (saveFileDialogResult == DialogResult.OK) {
                FilePath = saveFileDialog.FileName;
                SaveFile(FilePath);
                modified = false;

                UpdateTitle();
            }
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e) {
            quitApplication = true;
            Close();
        }

        private void metadataToolStripMenuItem_Click(object sender, EventArgs e) {
            MessageBox.Show("Not Implemented Yet >:(", "Alert");
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
            AboutWindow aboutWindow = new AboutWindow(this);
            aboutWindow.Show();
        }

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e) {
            MessageBox.Show("Not Implemented Yet >:(", "Alert");
        }

        private void EditorWindow_Activated(object sender, EventArgs e) {
            UpdateDictionaries();
            UpdateIntents();
        }
    }
}
