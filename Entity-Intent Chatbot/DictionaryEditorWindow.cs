using Dictionary = aytimothy.EIChatbot.Data.Dictionary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using aytimothy.EIChatbot.Data;

namespace aytimothy.EIChatbot.Editor {
    public partial class DictionaryEditorWindow : Form {
        public EditorWindow ParentWindow;
        public EventHandler<DictionaryEditorWindowEndEditEvent> OnCompleteEvent;
        public Dictionary Data;
        public List<VocabularyEditorWindow> Editors = new List<VocabularyEditorWindow>();
        public bool modified;

        public DictionaryEditorWindow(EditorWindow parent) {
            InitializeComponent();
            ParentWindow = parent;

            Data = new Dictionary();
            Data.GUID = EditorUtils.ByteArrayToHexString(EditorUtils.GenerateNextGUID());
            UpdateViews();
        }

        public DictionaryEditorWindow(EditorWindow parent, Dictionary existingData) {
            InitializeComponent();
            ParentWindow = parent;

            Data = existingData;
            UpdateViews();
        }

        public void UpdateViews() {
            VocabularyView.Rows.Clear();

            foreach (Vocabulary vocabulary in Data.Vocabulary)
                VocabularyView.Rows.Add(new string[3] { vocabulary.GUID, vocabulary.Meaning, vocabulary.Synonyms.Length.ToString() });

            GUIDTextBox.Text = Data.GUID;
            NameTextBox.Text = Data.Name;
            DescriptionTextBox.Text = Data.Description;
        }

        private void VocabularyAddButton_Click(object sender, EventArgs e) {
            VocabularyEditorWindow vocabularyEditor = new VocabularyEditorWindow(this);
            vocabularyEditor.Show();
            Editors.Add(vocabularyEditor);
            vocabularyEditor.OnEndEdit += OnEndEdit;
        }

        /// <summary>
        /// Triggers when the vocabulary editing window is closed. It saves all the data back into the array.
        /// </summary>
        /// <remarks>
        /// If the Vocabulary entry exists, it overrides the previous one.
        /// Otherwise, it would add a new element to the array.
        /// </remarks>
        /// <param name="sender">The vocabulary editor window that just closed.</param>
        /// <param name="e">Event data (the new vocabulary data) to replace the current data.</param>
        private void OnEndEdit(object sender, OnVocabularyEndEdit e) {
            VocabularyEditorWindow _sender = (VocabularyEditorWindow) sender;
            Editors.Remove(_sender);

            bool exists = false;
            if (Data.Vocabulary.Length > 0) {
                for (int i = 0; i < Data.Vocabulary.Length; i++) {
                    if (Data.Vocabulary[i].GUID == e.Data.GUID) {
                        exists = true;
                        Data.Vocabulary[i] = e.Data;
                    }
                }
            }
            if (!exists) {
                Array.Resize<Vocabulary>(ref Data.Vocabulary, Data.Vocabulary.Length + 1);
                Data.Vocabulary[Data.Vocabulary.Length - 1] = e.Data;
            }

            UpdateViews();

            modified = true;
        }

        private void VocabularyEditButton_Click(object sender, EventArgs e) {
            string guid = (string)VocabularyView.Rows[VocabularyView.CurrentCell.RowIndex].Cells[0].Value;

            bool found = false;
            foreach (Vocabulary vocabulary in Data.Vocabulary)
                if (vocabulary.GUID.ToUpper() == guid.ToUpper()) {
                    VocabularyEditorWindow intentEditor = new VocabularyEditorWindow(this, vocabulary);
                    intentEditor.OnEndEdit += OnEndEdit;
                    Editors.Add(intentEditor);
                    intentEditor.Show();
                    found = true;
                    break;
                }

            if (!found) {
                MessageBox.Show("Could not find vocabulary with GUID: \"" + guid.ToUpper() + "\".", "Error!");
            }
        }

        private void VocabularyRemoveButton_Click(object sender, EventArgs e) {
            string guid = (string)VocabularyView.Rows[VocabularyView.CurrentCell.RowIndex].Cells[0].Value;

            bool found = false;
            int index = -1;
            for (int i = 0; i < Data.Vocabulary.Length; i++) {
                if (Data.Vocabulary[i].GUID.ToUpper() == guid.ToUpper()) {
                    found = true;
                    index = i;
                    continue;
                }
                if (found)
                    Data.Vocabulary[i - 1] = Data.Vocabulary[i];
            }

            if (!found)
                MessageBox.Show("Could not find intent with GUID: \"" + guid.ToUpper() + "\".", "Error!");
            if (found)
                Array.Resize<Vocabulary>(ref Data.Vocabulary, Data.Vocabulary.Length - 1);

            UpdateViews();
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e) {
            TextBox textbox = (TextBox) sender;
            Data.Name = textbox.Text;
            modified = true;
        }

        private void DescriptionTextBox_TextChanged(object sender, EventArgs e) {
            TextBox textbox = (TextBox) sender;
            Data.Description = textbox.Text;
            modified = true;
        }

        private void DictionaryEditorWindow_FormClosed(object sender, FormClosedEventArgs e) {
            if (modified)
                OnCompleteEvent.Invoke(this, new DictionaryEditorWindowEndEditEvent() {
                    Data = Data,
                    DialogResult = DialogResult.OK
                });
            if (!modified)
                OnCompleteEvent.Invoke(this, new DictionaryEditorWindowEndEditEvent() {
                    Data = Data,
                    DialogResult = DialogResult.Cancel
                });
        }
    }

    public class DictionaryEditorWindowEndEditEvent : EventArgs {
        public Dictionary Data;
        public DialogResult DialogResult;
    }
}
