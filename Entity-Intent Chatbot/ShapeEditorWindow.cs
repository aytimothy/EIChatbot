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
        private bool modified;

        private void ShapeEditorWindow_Load(object sender, EventArgs e) {
            modified = true;
        }

        private void FillValues() {
            ShapeTextBox.Text = Data.ShapeString;
            GUIDTextBox.Text = Data.GUID;
            LanguageComboBox.SelectedIndex = 0;
        }

        public ShapeEditorWindow(IntentEditorWindow parent) {
            InitializeComponent();
            ParentWindow = parent;
            Data = new Shape("");
            Data.GUID = EditorUtils.ByteArrayToHexString(EditorUtils.GenerateNextGUID());
            FillValues();
        }

        public ShapeEditorWindow(IntentEditorWindow parent, Shape existingData) {
            InitializeComponent();
            ParentWindow = parent;
            Data = existingData;
            FillValues();
        }

        private void ShapeEditorWindow_FormClosed(object sender, FormClosedEventArgs e) {
            OnShapeEndEdit result = new OnShapeEndEdit() {
                Data = Data,
                DialogResult = (modified) ? DialogResult.OK : DialogResult.Cancel
            };
            OnEndEdit.Invoke(this, result);
        }

        private void ShapeText_TextChanged(object sender, EventArgs e) {
            modified = true;
            Data.ShapeString = ShapeTextBox.Text;
        }

        private void ShapeText_KeyPress(object sender, KeyPressEventArgs e) {

        }

        private void ShapeText_Leave(object sender, EventArgs e) {

        }

        private void EntityTabControl_TabIndexChanged(object sender, EventArgs e) {

        }

        public List<EntityEditorTab> ShapeTabs;

        private void RegenerateEntities() {

        }

        private void RefreshEntities() {

        }
    }

    public class EntityEditorTab : TabPage {
        public TabControl Parent;

        public Label TypeLabel;
        public Label MatchStringLabel;
        public Label SourceStringLabel;
        public Label OutputEntitySlotLabel;
        public Label PartialThresholdLabel;
        public CheckBox IsOutputEntityCheckBox;
        public ComboBox TypeComboBox;
        public TextBox MatchStringSourceTextBox;
        public ComboBox MatchStringDictionarySourceComboBox;
        public TextBox SourceStringTextBox;
        public ComboBox OutputEntitySlotComboBox;
        public TextBox PartialThresholdTextBox;

        public Entity Data;
        public int SourceIndex;

        public void InitializeComponent() {
            TypeLabel = new Label();
            MatchStringLabel = new Label();
            SourceStringLabel = new Label();
            OutputEntitySlotLabel = new Label();
            PartialThresholdLabel = new Label();
            IsOutputEntityCheckBox = new CheckBox();
            TypeComboBox = new ComboBox();
            MatchStringSourceTextBox = new TextBox();
            MatchStringDictionarySourceComboBox = new ComboBox();
            SourceStringTextBox = new TextBox();
            OutputEntitySlotComboBox = new ComboBox();
            PartialThresholdTextBox = new TextBox();

            TypeLabel.Text = "Type";
            MatchStringLabel.Text = "Match String";
            SourceStringLabel.Text = "Source String";
            OutputEntitySlotLabel.Text = "Output Entity";
            PartialThresholdLabel.Text = "Threshold";
            IsOutputEntityCheckBox.Text = "Is Output Entity";

            TypeLabel.Parent = this;
            MatchStringLabel.Parent = this;
            SourceStringLabel.Parent = this;
            OutputEntitySlotLabel.Parent = this;
            PartialThresholdLabel.Parent = this;
            IsOutputEntityCheckBox.Parent = this;
            TypeComboBox.Parent = this;
            MatchStringSourceTextBox.Parent = this;
            MatchStringDictionarySourceComboBox.Parent = this;
            SourceStringTextBox.Parent = this;
            OutputEntitySlotComboBox.Parent = this;
            PartialThresholdTextBox.Parent = this;

            // todo: Position Controls

            IsOutputEntityCheckBox.CheckedChanged += IsOutputEntityCheckBoxOnCheckedChanged;
            TypeComboBox.SelectedValueChanged += TypeComboBoxOnSelectedValueChanged;
            MatchStringSourceTextBox.TextChanged += MatchStringSourceTextBoxOnTextChanged;
            MatchStringDictionarySourceComboBox.SelectedValueChanged += MatchStringDictionarySourceComboBoxOnSelectedValueChanged;
            SourceStringTextBox.TextChanged += SourceStringTextBoxOnTextChanged;
            OutputEntitySlotComboBox.SelectedValueChanged += OutputEntitySlotComboBoxOnSelectedValueChanged;
            PartialThresholdTextBox.TextChanged += PartialThresholdTextBoxOnTextChanged;

            TypeLabel.Show();
            MatchStringLabel.Show();
            SourceStringLabel.Show();
            OutputEntitySlotLabel.Show();
            PartialThresholdLabel.Show();
            IsOutputEntityCheckBox.Show();
            TypeComboBox.Show();
            MatchStringSourceTextBox.Show();
            MatchStringDictionarySourceComboBox.Show();
            SourceStringTextBox.Show();
            OutputEntitySlotComboBox.Show();
            PartialThresholdTextBox.Show();
        }

        public EntityEditorTab(TabControl Parent) {
            this.Parent = Parent;
            this.Data = new MatchEntity();
            InitializeComponent();
        }

        public EntityEditorTab(TabControl Parent, Entity Data) {
            this.Parent = Parent;
            this.Data = Data;
            InitializeComponent();
        }

        private void IsOutputEntityCheckBoxOnCheckedChanged(object sender, EventArgs e) {
            throw new NotImplementedException();
        }

        private void TypeComboBoxOnSelectedValueChanged(object sender, EventArgs e) {
            throw new NotImplementedException();
        }
        private void PartialThresholdTextBoxOnTextChanged(object sender, EventArgs e) {
            throw new NotImplementedException();
        }

        private void OutputEntitySlotComboBoxOnSelectedValueChanged(object sender, EventArgs e) {
            throw new NotImplementedException();
        }

        private void SourceStringTextBoxOnTextChanged(object sender, EventArgs e) {
            throw new NotImplementedException();
        }

        private void MatchStringDictionarySourceComboBoxOnSelectedValueChanged(object sender, EventArgs e) {
            throw new NotImplementedException();
        }

        private void MatchStringSourceTextBoxOnTextChanged(object sender, EventArgs e) {
            throw new NotImplementedException();
        }
    }

    public class OnShapeEndEdit : EventArgs {
        public Shape Data;
        public DialogResult DialogResult;
    }
}
