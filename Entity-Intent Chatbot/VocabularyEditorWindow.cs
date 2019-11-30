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
    public partial class VocabularyEditorWindow : Form {
        public DictionaryEditorWindow Parent;
        public EventHandler<OnVocabularyEndEdit> OnEndEdit;
        public Vocabulary Data;

        public VocabularyEditorWindow(DictionaryEditorWindow parentWindow) {
            InitializeComponent();
            Parent = parentWindow;
            Data = new Vocabulary();
            Data.GUID = EditorUtils.ByteArrayToHexString(EditorUtils.GenerateNextGUID());
        }

        public VocabularyEditorWindow(DictionaryEditorWindow parentWindow, Vocabulary existingData) {
            InitializeComponent();
            Parent = parentWindow;
            Data = existingData;
        }
    }

    public class OnVocabularyEndEdit : EventArgs {
        public Vocabulary Data;
    }
}
