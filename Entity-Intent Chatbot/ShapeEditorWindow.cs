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
            PartialThresholdLabel.Location = new System.Drawing.Point(6, 212);
            PartialThresholdLabel.Name = "TemplatePartialThresholdLabel";
            PartialThresholdLabel.Size = new System.Drawing.Size(127, 20);
            PartialThresholdLabel.TabIndex = 11;
            PartialThresholdLabel.Text = "Partial Threshold";
            
            PartialThresholdTextBox.Location = new System.Drawing.Point(170, 209);
            PartialThresholdTextBox.Name = "TemplatePartialThresholdTextBox";
            PartialThresholdTextBox.Size = new System.Drawing.Size(614, 26);
            PartialThresholdTextBox.TabIndex = 10;
            PartialThresholdTextBox.TextChanged += PartialThresholdTextBoxOnTextChanged;
            
            OutputEntitySlotComboBox.FormattingEnabled = true;
            OutputEntitySlotComboBox.Items.AddRange(new object[] {
            "None",
            "Optional",
            "PartialMatch",
            "DirectMatch",
            "Match",
            "Wildcard",
            "DictionaryWildcard"});
            OutputEntitySlotComboBox.Location = new System.Drawing.Point(170, 175);
            OutputEntitySlotComboBox.Name = "TemplateOutputEntitySlotComboBox";
            OutputEntitySlotComboBox.Size = new System.Drawing.Size(614, 28);
            OutputEntitySlotComboBox.TabIndex = 9;
            OutputEntitySlotComboBox.SelectedIndexChanged += OutputEntitySlotComboBoxOnSelectedValueChanged;
            
            OutputEntitySlotLabel.AutoSize = true;
            OutputEntitySlotLabel.Location = new System.Drawing.Point(6, 178);
            OutputEntitySlotLabel.Name = "TemplateOutputEntitySlotLabel";
            OutputEntitySlotLabel.Size = new System.Drawing.Size(134, 20);
            OutputEntitySlotLabel.TabIndex = 8;
            OutputEntitySlotLabel.Text = "Output Entity Slot";
            
            IsOutputEntityCheckBox.AutoSize = true;
            IsOutputEntityCheckBox.Location = new System.Drawing.Point(10, 144);
            IsOutputEntityCheckBox.Name = "TemplateIsOutputEntityCheckBox";
            IsOutputEntityCheckBox.Size = new System.Drawing.Size(138, 24);
            IsOutputEntityCheckBox.TabIndex = 7;
            IsOutputEntityCheckBox.Text = "Is Output Entity";
            IsOutputEntityCheckBox.UseVisualStyleBackColor = true;
            IsOutputEntityCheckBox.CheckedChanged += IsOutputEntityCheckBoxOnCheckedChanged;
            
            MatchStringDictionarySourceComboBox.FormattingEnabled = true;
            MatchStringDictionarySourceComboBox.Items.AddRange(new object[] {
            "None",
            "Optional",
            "PartialMatch",
            "DirectMatch",
            "Match",
            "Wildcard",
            "DictionaryWildcard"});
            MatchStringDictionarySourceComboBox.Location = new System.Drawing.Point(170, 44);
            MatchStringDictionarySourceComboBox.Name = "TemplateMatchStringDictionaryComboBox";
            MatchStringDictionarySourceComboBox.Size = new System.Drawing.Size(614, 28);
            MatchStringDictionarySourceComboBox.TabIndex = 6;
            MatchStringDictionarySourceComboBox.SelectedIndexChanged += MatchStringDictionarySourceComboBoxOnSelectedValueChanged;
            
            SourceStringLabel.AutoSize = true;
            SourceStringLabel.Location = new System.Drawing.Point(6, 80);
            SourceStringLabel.Name = "TemplateSourceStringLabel";
            SourceStringLabel.Size = new System.Drawing.Size(106, 20);
            SourceStringLabel.TabIndex = 5;
            SourceStringLabel.Text = "Source String";
            
            SourceStringTextBox.Location = new System.Drawing.Point(170, 77);
            SourceStringTextBox.Name = "TemplateSourceStringTextBox";
            SourceStringTextBox.ReadOnly = true;
            SourceStringTextBox.Size = new System.Drawing.Size(614, 26);
            SourceStringTextBox.TabIndex = 4;
            SourceStringTextBox.TextChanged += SourceStringTextBoxOnTextChanged;
            
            MatchStringSourceTextBox.Location = new System.Drawing.Point(170, 44);
            MatchStringSourceTextBox.Name = "TemplateMatchStringTextBox";
            MatchStringSourceTextBox.Size = new System.Drawing.Size(614, 26);
            MatchStringSourceTextBox.TabIndex = 3;
            MatchStringSourceTextBox.TextChanged += MatchStringSourceTextBoxOnTextChanged;


            MatchStringLabel.AutoSize = true;
            MatchStringLabel.Location = new System.Drawing.Point(6, 47);
            MatchStringLabel.Name = "TemplateMatchStringLabel";
            MatchStringLabel.Size = new System.Drawing.Size(99, 20);
            MatchStringLabel.TabIndex = 2;
            MatchStringLabel.Text = "Match String";
            
            TypeComboBox.FormattingEnabled = true;
            TypeComboBox.Items.AddRange(new object[] {
            "None",
            "Optional",
            "PartialMatch",
            "DirectMatch",
            "Match",
            "Wildcard",
            "DictionaryWildcard"});
            TypeComboBox.Location = new System.Drawing.Point(170, 10);
            TypeComboBox.Name = "TemplateTypeComboBox";
            TypeComboBox.Size = new System.Drawing.Size(614, 28);
            TypeComboBox.TabIndex = 1;
            TypeComboBox.SelectedIndexChanged += TypeComboBoxOnSelectedValueChanged;
            
            TypeLabel.AutoSize = true;
            TypeLabel.Location = new System.Drawing.Point(6, 13);
            TypeLabel.Name = "TemplateTypeLabel";
            TypeLabel.Size = new System.Drawing.Size(43, 20);
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

        private void IsOutputEntityCheckBoxOnCheckedChanged(object sender, EventArgs e) {
            if (isSetup)
                return;

            Root.Modified = true;
            Data.IsOutputEntity = IsOutputEntityCheckBox.Checked;
        }

        private void TypeComboBoxOnSelectedValueChanged(object sender, EventArgs e) {
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
        }

        private void MatchStringSourceTextBoxOnTextChanged(object sender, EventArgs e) {
            if (isSetup)
                return;

            Root.Modified = true;
        }
    }

    public class OnShapeEndEdit : EventArgs {
        public Shape Data;
        public DialogResult DialogResult;
    }
}
