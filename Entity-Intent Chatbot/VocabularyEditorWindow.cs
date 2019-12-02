using aytimothy.EIChatbot.Data;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace aytimothy.EIChatbot.Editor {
    public partial class VocabularyEditorWindow : Form {
        public DictionaryEditorWindow Parent;
        public EventHandler<OnVocabularyEndEdit> OnEndEdit;
        public Vocabulary Data;

        public bool modified = false;

        public VocabularyEditorWindow(DictionaryEditorWindow parentWindow) {
            InitializeComponent();
            Parent = parentWindow;
            Data = new Vocabulary();
            Data.GUID = EditorUtils.ByteArrayToHexString(EditorUtils.GenerateNextGUID());
            modified = true;

            UpdateViews();
        }

        public VocabularyEditorWindow(DictionaryEditorWindow parentWindow, Vocabulary existingData) {
            InitializeComponent();
            Parent = parentWindow;
            Data = existingData;

            UpdateViews();
        }

        private void VocabularyEditorWindow_FormClosed(object sender, FormClosedEventArgs e) {
            if (modified)
                OnEndEdit.Invoke(this, new OnVocabularyEndEdit() {
                    Data = Data,
                    DialogResult = DialogResult.OK
                });
            if (!modified)
                OnEndEdit.Invoke(this, new OnVocabularyEndEdit() {
                    Data = Data,
                    DialogResult = DialogResult.Cancel
                });
        }

        private void SynonymAddButton_Click(object sender, EventArgs e) {
            string newWord = Interaction.InputBox("Enter new word to add:", "Add New Word", "");
            if (!String.IsNullOrEmpty(newWord)) {
                Array.Resize<string>(ref Data.Synonyms, Data.Synonyms.Length + 1);
                Data.Synonyms[Data.Synonyms.Length - 1] = newWord;
                modified = true;
            }

            UpdateViews();
        }

        private void SynonymEditButton_Click(object sender, EventArgs e) {
            int index = -1;
            string matchString = (string)SynonymsDataView.Rows[SynonymsDataView.CurrentCell.RowIndex].Cells[0].Value;
            for (int i = 0; i < Data.Synonyms.Length; i++)
                if (Data.Synonyms[i] == matchString) {
                    index = i;
                    break;
                }

            if (index == -1) {
                MessageBox.Show("Could not find the synonym \"" + matchString + "\"...", "Error!");
                return;
            }

            string newString = Interaction.InputBox("Enter modified synonym:", "Modify Synonym", matchString);
            if (newString != matchString && !String.IsNullOrEmpty(newString)) {
                Data.Synonyms[index] = newString;
                modified = true;
            }

            UpdateViews();
        }

        private void SynonymRemoveButton_Click(object sender, EventArgs e) {
            string synonym = (string) SynonymsDataView.Rows[SynonymsDataView.CurrentCell.RowIndex].Cells[0].Value;

            bool found = false;
            int index = -1;
            for (int i = 0; i < Data.Synonyms.Length; i++) {
                if (Data.Synonyms[i] == synonym) {
                    found = true;
                    index = i;
                    continue;
                }

                if (found)
                    Data.Synonyms[i - 1] = Data.Synonyms[i];
            }
            if (found)
                Array.Resize<string>(ref Data.Synonyms, Data.Synonyms.Length - 1);
            if (!found)
                MessageBox.Show("Error: Could not remove synonym as it does not exist.");

            UpdateViews();
        }

        private void MeaningTextBox_TextChanged(object sender, EventArgs e) {
            TextBox _sender = (TextBox) sender;
            Data.Meaning = _sender.Text;
            modified = true;
        }

        public void UpdateViews() {
            GUIDTextBox.Text = Data.GUID;
            MeaningTextBox.Text = Data.Meaning;

            SynonymsDataView.Rows.Clear();
            foreach (string synonym in Data.Synonyms) {
                SynonymsDataView.Rows.Add(new string[1] {synonym});
            }
        }
    }

    public class OnVocabularyEndEdit : EventArgs {
        public Vocabulary Data;
        public DialogResult DialogResult;
    }
}
