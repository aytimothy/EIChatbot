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

        public ShapeEditorWindow(IntentEditorWindow parent) {
            InitializeComponent();
            ParentWindow = parent;
            Data = new Shape("");
        }

        public ShapeEditorWindow(IntentEditorWindow parent, Shape existingData) {
            InitializeComponent();
            ParentWindow = parent;
            Data = existingData;

            throw new NotImplementedException();
        }
    }

    public class OnShapeEndEdit : EventArgs {
        public Shape Data;
        public DialogResult DialogResult;
    }
}
