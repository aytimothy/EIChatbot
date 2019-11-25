using Dictionary = aytimothy.EIChatbot.Data.Dictionary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace aytimothy.EIChatbot.Editor {
    public partial class DictionaryEditorWindow : Form {
        public EditorWindow ParentWindow;
        public EventHandler<DictionaryEditorWindowEndEditEvent> OnCompleteEvent;
        public Dictionary Data;
        public List<VocabularyEditorWindow> Editors = new List<VocabularyEditorWindow>();

        public DictionaryEditorWindow(EditorWindow parent) {
            InitializeComponent();
            ParentWindow = parent;
        }

        public DictionaryEditorWindow(EditorWindow parent, Dictionary existingData) {
            InitializeComponent();
            ParentWindow = parent;

            throw new NotImplementedException();
        }

        private void VocabularyAddButton_Click(object sender, EventArgs e) {
            VocabularyEditorWindow vocabularyEditor = new VocabularyEditorWindow(this);
            vocabularyEditor.Show();
            Editors.Add(vocabularyEditor);
            vocabularyEditor.OnEndEdit += OnEndEdit;
        }

        private void OnEndEdit(object sender, OnVocabularyEndEdit e) {
            VocabularyEditorWindow _sender = (VocabularyEditorWindow) sender;
            Editors.Remove(_sender);

            throw new NotImplementedException();
        }

        private void VocabularyEditButton_Click(object sender, EventArgs e) {

        }

        private void VocabularyRemoveButton_Click(object sender, EventArgs e) {

        }

        private void NameTextBox_TextChanged(object sender, EventArgs e) {

        }

        private void DescriptionTextBox_TextChanged(object sender, EventArgs e) {

        }
    }

    public class DictionaryEditorWindowEndEditEvent : EventArgs {
        public Dictionary NewData;
        public DialogResult DialogResult;
    }
}
