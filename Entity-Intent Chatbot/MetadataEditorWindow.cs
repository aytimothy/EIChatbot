using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aytimothy.EIChatbot.Editor {
    public partial class MetadataEditorWindow : Form {
        public EditorWindow Parent;
        bool isPrefilling = false;

        public MetadataEditorWindow(EditorWindow Parent) {
            InitializeComponent();
            this.Parent = Parent;
            Prefill();
        }

        void Prefill() {
            isPrefilling = true;
            if (Parent != null) {
                NameTextBox.Text = Parent.Data.AgentName;
                AuthorTextBox.Text = Parent.Data.Author;
                DescriptionTextBox.Text = Parent.Data.Description;
            }
            if (Parent == null) {
                MessageBox.Show("Could not find a knowledgebase to edit...", "Error!");
                Close();
            }
            isPrefilling = false;
        }

        void NameTextBox_TextChanged(object sender, EventArgs e) {
            if (isPrefilling || Parent == null)
                return;
            Parent.Data.AgentName = NameTextBox.Text;
        }

        void AuthorTextBox_TextChanged(object sender, EventArgs e) {
            if (isPrefilling || Parent == null)
                return;
            Parent.Data.Author = AuthorTextBox.Text;
        }

        void DescriptionTextBox_TextChanged(object sender, EventArgs e) {
            if (isPrefilling || Parent == null)
                return;
            Parent.Data.Description = DescriptionTextBox.Text;
        }
    }
}
