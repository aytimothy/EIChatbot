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
        public bool Modified;
        private bool isSetup;

        private void ShapeEditorWindow_Load(object sender, EventArgs e) {
            EntityTabControl.Controls.Remove(TemplateTabPage);
        }

        private void FillValues() {
            ShapeTextBox.Text = Data.ShapeString;
            GUIDTextBox.Text = Data.GUID;
            LanguageComboBox.SelectedIndex = 0;

            RefreshEntities();
        }

        public ShapeEditorWindow(IntentEditorWindow parent) {
            isSetup = true;
            InitializeComponent();
            ParentWindow = parent;
            Data = new Shape("");
            Data.GUID = EditorUtils.ByteArrayToHexString(EditorUtils.GenerateNextGUID());
            FillValues();
            isSetup = false;
        }

        public ShapeEditorWindow(IntentEditorWindow parent, Shape existingData) {
            isSetup = true;
            InitializeComponent();
            ParentWindow = parent;
            Data = existingData;
            FillValues();
            isSetup = false;
        }

        private void ShapeEditorWindow_FormClosed(object sender, FormClosedEventArgs e) {
            List<Entity> entities = new List<Entity>();
            foreach (EntityEditorTab tab in ShapeTabs)
                entities.Add(tab.Data);
            Data.Entities = entities.ToArray();

            OnShapeEndEdit result = new OnShapeEndEdit() {
                Data = Data,
                DialogResult = (Modified) ? DialogResult.OK : DialogResult.Cancel
            };
            OnEndEdit.Invoke(this, result);
        }

        private void ShapeText_TextChanged(object sender, EventArgs e) {
            if (isSetup)
                return;

            Modified = true;
            Data.ShapeString = ShapeTextBox.Text;

            RefreshEntities(true);
            ActiveControl = ShapeTextBox;
        }

        private void ShapeText_KeyPress(object sender, KeyPressEventArgs e) {
            if (isSetup)
                return;
        }

        private void ShapeText_Leave(object sender, EventArgs e) {
            if (isSetup)
                return;
        }

        private void ShapeText_LostFocus(object sender, EventArgs e) {
            if (isSetup)
                return;
        }

        private void EntityTabControl_TabIndexChanged(object sender, EventArgs e) {
            if (isSetup)
                return;
        }

        public List<EntityEditorTab> ShapeTabs = new List<EntityEditorTab>();

        private void RefreshEntities(bool clean = false) {
            foreach (EntityEditorTab Tab in ShapeTabs)
                Tab.DeinitializeComponent();
            ShapeTabs.Clear();

            if (clean)
                RegenerateEntities();
            if (!clean)
                ReloadEntities();
        }

        private void RegenerateEntities() {
            string shapeString = ShapeTextBox.Text;
            string[] splitString = shapeString.Split(' ');

            // todo: Not recreate the tabs always, and only create new ones where necessary...
            int i = 0;
            foreach (string stringPart in splitString) {
                if (String.IsNullOrEmpty(stringPart))
                    continue;
                EntityEditorTab tab = new EntityEditorTab(EntityTabControl, this, new Entity() {
                    IsOutputEntity = false,
                    MatchThreshold = 1f,
                    OutputEntityGUID = null,
                    RawContents = stringPart,
                    SourceString = stringPart.ToLower().Replace(" ", string.Empty).Replace("-", string.Empty),
                    Type = EntityType.Match
                }, i);
                i++;
                ShapeTabs.Add(tab);
            }

            EntityCountLabel.Text = "Entities: " + ShapeTabs.Count;
        }

        private void ReloadEntities() {
            for (int i = 0; i < Data.Entities.Length; i++) {
                EntityEditorTab tab = new EntityEditorTab(EntityTabControl, this, Data.Entities[i], i);
                ShapeTabs.Add(tab);
            }

            EntityCountLabel.Text = "Entities: " + ShapeTabs.Count;
        }
    }

    public class EntityEditorTab {
        public TabControl Parent;
        public ShapeEditorWindow Root;
        public TabPage Page;

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
        private bool isSetup;
        private bool modified {
            get { return Root.Modified; }
            set { Root.Modified = value; }
        }

        public void InitializeComponent() {
            isSetup = true;
            Page = new TabPage();
            PartialThresholdLabel = new Label();
            PartialThresholdTextBox = new TextBox();
            OutputEntitySlotComboBox = new ComboBox();
            OutputEntitySlotLabel = new Label();
            IsOutputEntityCheckBox = new CheckBox();
            MatchStringDictionarySourceComboBox = new ComboBox();
            SourceStringLabel = new Label();
            SourceStringTextBox = new TextBox();
            MatchStringSourceTextBox = new TextBox();
            MatchStringLabel = new Label();
            TypeComboBox = new ComboBox();
            TypeLabel = new Label();

            Parent.SuspendLayout();
            Page.SuspendLayout();
            Root.SuspendLayout();

            Parent.Controls.Add(Page);

            Page.Controls.Add(PartialThresholdLabel);
            Page.Controls.Add(PartialThresholdTextBox);
            Page.Controls.Add(OutputEntitySlotComboBox);
            Page.Controls.Add(OutputEntitySlotLabel);
            Page.Controls.Add(IsOutputEntityCheckBox);
            Page.Controls.Add(MatchStringDictionarySourceComboBox);
            Page.Controls.Add(SourceStringLabel);
            Page.Controls.Add(SourceStringTextBox);
            Page.Controls.Add(MatchStringSourceTextBox);
            Page.Controls.Add(MatchStringLabel);
            Page.Controls.Add(TypeComboBox);
            Page.Controls.Add(TypeLabel);
            Page.Location = new Point(4, 29);
            Page.Name = "TemplateTabPage";
            Page.Padding = new Padding(3);
            Page.Size = new Size(790, 360);
            Page.TabIndex = 0;
            Page.Text = "TemplateTabPage";
            Page.UseVisualStyleBackColor = true;

            PartialThresholdLabel.AutoSize = true;
            PartialThresholdLabel.Location = new Point(4, 138);
            PartialThresholdLabel.Margin = new Padding(2, 0, 2, 0);
            PartialThresholdLabel.Name = "TemplatePartialThresholdLabel";
            PartialThresholdLabel.Size = new Size(86, 13);
            PartialThresholdLabel.TabIndex = 11;
            PartialThresholdLabel.Text = "Partial Threshold";

            PartialThresholdTextBox.Location = new Point(113, 136);
            PartialThresholdTextBox.Margin = new Padding(2, 2, 2, 2);
            PartialThresholdTextBox.Name = "TemplatePartialThresholdTextBox";
            PartialThresholdTextBox.Size = new Size(407, 20);
            PartialThresholdTextBox.TabIndex = 10;
            PartialThresholdTextBox.TextChanged += PartialThresholdTextBoxOnTextChanged;

            OutputEntitySlotComboBox.FormattingEnabled = true;
            OutputEntitySlotComboBox.Items.AddRange(new object[] {
            "None",
            "Optional",
            "Partial Match",
            "Direct Match",
            "Match",
            "Wildcard",
            "Dictionary Wildcard",
            "Special Wildcard"});
            OutputEntitySlotComboBox.Location = new Point(113, 114);
            OutputEntitySlotComboBox.Margin = new Padding(2, 2, 2, 2);
            OutputEntitySlotComboBox.Name = "TemplateOutputEntitySlotComboBox";
            OutputEntitySlotComboBox.Size = new Size(407, 21);
            OutputEntitySlotComboBox.TabIndex = 9;
            OutputEntitySlotComboBox.SelectedIndexChanged += OutputEntitySlotComboBoxOnSelectedValueChanged;

            OutputEntitySlotLabel.AutoSize = true;
            OutputEntitySlotLabel.Location = new Point(4, 116);
            OutputEntitySlotLabel.Margin = new Padding(2, 0, 2, 0);
            OutputEntitySlotLabel.Name = "TemplateOutputEntitySlotLabel";
            OutputEntitySlotLabel.Size = new Size(89, 13);
            OutputEntitySlotLabel.TabIndex = 8;
            OutputEntitySlotLabel.Text = "Output Entity Slot";

            IsOutputEntityCheckBox.AutoSize = true;
            IsOutputEntityCheckBox.Location = new Point(7, 94);
            IsOutputEntityCheckBox.Margin = new Padding(2, 2, 2, 2);
            IsOutputEntityCheckBox.Name = "TemplateIsOutputEntityCheckBox";
            IsOutputEntityCheckBox.Size = new Size(98, 17);
            IsOutputEntityCheckBox.TabIndex = 7;
            IsOutputEntityCheckBox.Text = "Is Output Entity";
            IsOutputEntityCheckBox.UseVisualStyleBackColor = true;
            IsOutputEntityCheckBox.CheckedChanged += IsOutputEntityCheckBoxOnCheckedChanged;

            MatchStringDictionarySourceComboBox.FormattingEnabled = true;
            MatchStringDictionarySourceComboBox.Items.AddRange(new object[] { "Not Implemented Yet"});
            MatchStringDictionarySourceComboBox.Location = new Point(113, 29);
            MatchStringDictionarySourceComboBox.Margin = new Padding(2, 2, 2, 2);
            MatchStringDictionarySourceComboBox.Name = "TemplateMatchStringDictionaryComboBox";
            MatchStringDictionarySourceComboBox.Size = new Size(407, 21);
            MatchStringDictionarySourceComboBox.TabIndex = 6;
            MatchStringDictionarySourceComboBox.SelectedIndexChanged += MatchStringDictionarySourceComboBoxOnSelectedIndexChanged;

            SourceStringLabel.AutoSize = true;
            SourceStringLabel.Location = new Point(4, 54);
            SourceStringLabel.Margin = new Padding(2, 0, 2, 0);
            SourceStringLabel.Name = "TemplateSourceStringLabel";
            SourceStringLabel.Size = new Size(71, 13);
            SourceStringLabel.TabIndex = 5;
            SourceStringLabel.Text = "Source String";

            SourceStringTextBox.Location = new Point(113, 52);
            SourceStringTextBox.Margin = new Padding(2, 2, 2, 2);
            SourceStringTextBox.Name = "TemplateSourceStringTextBox";
            SourceStringTextBox.ReadOnly = true;
            SourceStringTextBox.Size = new Size(407, 20);
            SourceStringTextBox.TabIndex = 4;
            SourceStringTextBox.TextChanged += SourceStringTextBoxOnTextChanged;

            MatchStringSourceTextBox.Location = new Point(113, 29);
            MatchStringSourceTextBox.Margin = new Padding(2, 2, 2, 2);
            MatchStringSourceTextBox.Name = "TemplateMatchStringTextBox";
            MatchStringSourceTextBox.Size = new Size(407, 20);
            MatchStringSourceTextBox.TabIndex = 3;
            MatchStringSourceTextBox.TextChanged += MatchStringSourceTextBoxOnTextChanged;


            MatchStringLabel.AutoSize = true;
            MatchStringLabel.Location = new Point(4, 31);
            MatchStringLabel.Margin = new Padding(2, 0, 2, 0);
            MatchStringLabel.Name = "TemplateMatchStringLabel";
            MatchStringLabel.Size = new Size(67, 13);
            MatchStringLabel.TabIndex = 2;
            MatchStringLabel.Text = "Match String";

            TypeComboBox.FormattingEnabled = true;
            TypeComboBox.Items.AddRange(new object[] {
            "None",
            "Optional",
            "Partial Match",
            "Direct Match",
            "Match",
            "Wildcard",
            "Dictionary Wildcard",
            "Special Wildcard"});
            TypeComboBox.Location = new Point(113, 6);
            TypeComboBox.Margin = new Padding(2, 2, 2, 2);
            TypeComboBox.Name = "TemplateTypeComboBox";
            TypeComboBox.Size = new Size(407, 21);
            TypeComboBox.TabIndex = 1;
            TypeComboBox.SelectedIndexChanged += TypeComboBoxOnSelectedValueChanged;

            TypeLabel.AutoSize = true;
            TypeLabel.Location = new Point(4, 8);
            TypeLabel.Margin = new Padding(2, 0, 2, 0);
            TypeLabel.Name = "TemplateTypeLabel";
            TypeLabel.Size = new Size(31, 13);
            TypeLabel.TabIndex = 0;
            TypeLabel.Text = "Type";

            Parent.ResumeLayout(false);
            Page.ResumeLayout(false);
            Page.PerformLayout();
            Root.ResumeLayout(false);
            Root.PerformLayout();
            isSetup = false;
        }

        public void DeinitializeComponent() {
            Parent.TabPages.Remove(Page);
            Page.Dispose();
        }

        public EntityEditorTab(TabControl Parent, ShapeEditorWindow Root) {
            this.Parent = Parent;
            this.Root = Root;
            this.Data = new MatchEntity();
            InitializeComponent();
            FillValues();
        }

        public EntityEditorTab(TabControl Parent, ShapeEditorWindow Root, Entity Data, int Index) {
            SourceIndex = Index;
            this.Parent = Parent;
            this.Root = Root;
            this.Data = Data;
            InitializeComponent();
            FillValues();
        }

        public void FillValues() {
            FillValues(Data);
        }

        public void FillValues(Entity entity) {
            isSetup = true;
            Page.Text = entity.RawContents;
            TypeComboBox.SelectedIndex = (int) entity.Type;
            SourceStringTextBox.Text = entity.SourceString;
            // todo: Tell the difference between a dictionary and a string match.
            MatchStringSourceTextBox.Text = entity.RawContents;
            MatchStringDictionarySourceComboBox.Hide();
            IsOutputEntityCheckBox.Checked = entity.IsOutputEntity;
            // todo: Find index of the UUID.
            OutputEntitySlotComboBox.SelectedIndex = 0;
            PartialThresholdTextBox.Text = entity.MatchThreshold.ToString();
            isSetup = false;
        }

        private void MatchStringDictionarySourceComboBoxOnSelectedIndexChanged(object sender, EventArgs e) {
            if (isSetup)
                return;

            modified = true;
            // todo: Convert index to GUID.
        }

        private void IsOutputEntityCheckBoxOnCheckedChanged(object sender, EventArgs e) {
            if (isSetup)
                return;

            Root.Modified = true;
            Data.IsOutputEntity = IsOutputEntityCheckBox.Checked;
        }

        private void TypeComboBoxOnSelectedValueChanged(object sender, EventArgs e) {
            switch ((EntityType)TypeComboBox.SelectedIndex) {
                case EntityType.None:
                    MatchStringLabel.Visible = false;
                    MatchStringDictionarySourceComboBox.Visible = false;
                    MatchStringSourceTextBox.Visible = false;
                    PartialThresholdTextBox.Visible = false;
                    PartialThresholdLabel.Visible = false;
                    break;
                case EntityType.Optional:
                    MatchStringLabel.Visible = true;
                    MatchStringDictionarySourceComboBox.Visible = false;
                    MatchStringSourceTextBox.Visible = true;
                    PartialThresholdTextBox.Visible = false;
                    PartialThresholdLabel.Visible = false;
                    break;
                case EntityType.PartialMatch:
                    MatchStringLabel.Visible = true;
                    MatchStringDictionarySourceComboBox.Visible = false;
                    MatchStringSourceTextBox.Visible = true;
                    PartialThresholdTextBox.Visible = true;
                    PartialThresholdLabel.Visible = true;
                    break;
                case EntityType.DirectMatch:
                    goto case EntityType.Optional;
                case EntityType.Match:
                    goto case EntityType.Optional;
                case EntityType.Wildcard:
                    goto case EntityType.None;
                    break;
                case EntityType.DictionaryWildcard:
                    MatchStringLabel.Visible = true;
                    MatchStringDictionarySourceComboBox.Visible = true;
                    MatchStringSourceTextBox.Visible = false;
                    // todo: Setup combo box for existing dictionaries
                    break;
                case EntityType.SpecialWildcard:
                    MatchStringLabel.Visible = true;
                    MatchStringDictionarySourceComboBox.Visible = true;
                    MatchStringSourceTextBox.Visible = false;
                    // todo: Setup combo box for special wildcards
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (isSetup)
                return;

            Root.Modified = true;
            Data.Type = (EntityType) TypeComboBox.SelectedIndex;

        }
        private void PartialThresholdTextBoxOnTextChanged(object sender, EventArgs e) {
            if (isSetup)
                return;

            float parseResult;
            bool parseAttempt = float.TryParse(PartialThresholdTextBox.Text, out parseResult);
            if (parseAttempt) {
                Data.MatchThreshold = parseResult;
                Root.Modified = true;
            }
        }

        private void OutputEntitySlotComboBoxOnSelectedValueChanged(object sender, EventArgs e) {
            if (isSetup)
                return;

            Root.Modified = true;
            // todo: Convert index to UUID.
            Data.OutputEntityGUID = "Not Implemented";
        }

        private void SourceStringTextBoxOnTextChanged(object sender, EventArgs e) {
            if (isSetup)
                return;

            Root.Modified = true;
            Data.SourceString = SourceStringTextBox.Text;
        }

        private void MatchStringDictionarySourceComboBoxOnSelectedValueChanged(object sender, EventArgs e) {
            if (isSetup)
                return;

            Root.Modified = true;
            // todo: Convert index to UUID.
        }

        private void MatchStringSourceTextBoxOnTextChanged(object sender, EventArgs e) {
            if (isSetup)
                return;

            Root.Modified = true;
            Data.SourceString = MatchStringSourceTextBox.Text;
        }
    }

    public class OnShapeEndEdit : EventArgs {
        public Shape Data;
        public DialogResult DialogResult;
    }
}
