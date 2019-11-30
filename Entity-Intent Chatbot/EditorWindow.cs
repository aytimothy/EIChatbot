using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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

            if (Data.Dictionaries == null)
                return;
            if (Data.Dictionaries.Length == null)
                return;
            foreach (Dictionary dictionary in Data.Dictionaries)
                DictionaryView.Rows.Add(dictionary.GUID, dictionary.Name, dictionary.Vocabulary.Length.ToString());
        }

        private void UpdateIntents() {
            IntentView.Rows.Clear();

            if (Data.Intents == null)
                return;
            if (Data.Intents.Length == 0)
                return;
            foreach (Intent intent in Data.Intents)
                IntentView.Rows.Add(intent.GUID, intent.IntentID, intent.IntentDomain, intent.Shapes.Length.ToString());
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

            bool exists = false;
            if (Data.Dictionaries.Length > 0) {
                for (int i = 0; i < Data.Dictionaries.Length; i++) {
                    if (Data.Dictionaries[i].GUID == e.Data.GUID) {
                        exists = true;
                        Data.Dictionaries[i] = e.Data;
                    }
                }
            }
            if (!exists) {
                Array.Resize<Dictionary>(ref Data.Dictionaries, Data.Dictionaries.Length + 1);
                Data.Dictionaries[Data.Dictionaries.Length - 1] = e.Data;
            }

            UpdateDictionaries();
            modified = true;
        }

        private void EditDictionaryButton_Click(object sender, EventArgs e) {
            if (DictionaryView.SelectedRows.Count <= 0) {
                MessageBox.Show("Please select a row to edit...", "Error!");
                return;
            }

            DataRow row = ((DataRowView)DictionaryView.SelectedRows[0].DataBoundItem).Row;
            string guid = (string)row.ItemArray[0];

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
            if (DictionaryView.SelectedRows.Count <= 0) {
                MessageBox.Show("Please select a row to edit...", "Error!");
                return;
            }

            DataRow row = ((DataRowView)DictionaryView.SelectedRows[0].DataBoundItem).Row;
            string guid = (string)row.ItemArray[0];

            bool found = false;
            int index = -1;
            for (int i = 0; i < Data.Dictionaries.Length - 1; i++) {
                if (Data.Dictionaries[i].GUID.ToUpper() == guid.ToUpper()) {
                    found = true;
                    index = i;
                }
                if (found)
                    Data.Dictionaries[i - 1] = Data.Dictionaries[i];
            }

            if (!found)
                MessageBox.Show("Could not find dictionary with GUID: \"" + guid.ToUpper() + "\".", "Error!");
            if (found)
                Array.Resize<Dictionary>(ref Data.Dictionaries, Data.Dictionaries.Length - 1);
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

            bool exists = false;
            if (Data.Intents.Length > 0) {
                for (int i = 0; i < Data.Intents.Length; i++) {
                    if (Data.Intents[i].GUID == e.Data.GUID) {
                        exists = true;
                        Data.Intents[i] = e.Data;
                    }
                }
            }
            if (!exists) {
                Array.Resize<Intent>(ref Data.Intents, Data.Intents.Length + 1);
                Data.Intents[Data.Intents.Length - 1] = e.Data;
            }

            UpdateIntents();

            modified = true;
        }

        private void EditIntentButton_Click(object sender, EventArgs e) {
            if (DictionaryView.SelectedRows.Count <= 0) {
                MessageBox.Show("Please select a row to edit...", "Error!");
                return;
            }

            DataRow row = ((DataRowView)DictionaryView.SelectedRows[0].DataBoundItem).Row;
            string guid = (string)row.ItemArray[0];

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
            if (DictionaryView.SelectedRows.Count <= 0) {
                MessageBox.Show("Please select a row to edit...", "Error!");
                return;
            }

            DataRow row = ((DataRowView)DictionaryView.SelectedRows[0].DataBoundItem).Row;
            string guid = (string)row.ItemArray[0];

            bool found = false;
            int index = -1;
            for (int i = 0; i < Data.Intents.Length - 1; i++) {
                if (Data.Intents[i].GUID.ToUpper() == guid.ToUpper()) {
                    found = true;
                    index = i;
                }
                if (found)
                    Data.Intents[i - 1] = Data.Intents[i];
            }

            if (!found)
                MessageBox.Show("Could not find intent with GUID: \"" + guid.ToUpper() + "\".", "Error!");
            if (found)
                Array.Resize<Intent>(ref Data.Intents, Data.Intents.Length - 1);
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
            MessageBox.Show("Alert", "Not Implemented Yet >:(");
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
            AboutWindow aboutWindow = new AboutWindow(this);
        }

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e) {
            MessageBox.Show("Alert", "Not Implemented Yet >:(");
        }
    }
}
