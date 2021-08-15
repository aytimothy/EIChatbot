using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            string regexPattern = "([.!~]+|[*+/\\-,:;@#$%^&_=?'\"<>)(])|([A-Za-z']+|[0-9/.]+)";
            MatchCollection matches = Regex.Matches(shapeString, regexPattern);
            List<string> splitString = new List<string>();
            foreach (var match in matches)
                splitString.Add(match.ToString());
            
            int i = 0;
            foreach (string stringPart in splitString) {
                // todo: Bug in refreshing that doesn't display the special textboxes for non-text-match shapes
                ShapeGenerationExtensions.SpecialWildcardDetectionResult wildcardDetectionResult;
                ShapeGenerationExtensions.DictionaryDetectionResult dictionaryDetectionResult;
                if (stringPart.TrySpecialParse(out wildcardDetectionResult)) {
                    // if match in a special wildcard
                }
                else if (stringPart.TryDictionaryParse(ParentWindow.ParentWindow.Data.Dictionaries, out dictionaryDetectionResult)) {
                    // if match in a dictionary somewhere
                }
                else if (stringPart.IsAlphaNumeric()) {
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
                else {
                    EntityEditorTab tab = new EntityEditorTab(EntityTabControl, this, new Entity() {
                        IsOutputEntity = false,
                        MatchThreshold = 0f,
                        OutputEntityGUID = null,
                        RawContents = stringPart,
                        SourceString = stringPart.ToLower().Replace(" ", string.Empty).Replace("-", string.Empty),
                        Type = EntityType.Optional
                    }, i);
                    i++;
                    ShapeTabs.Add(tab);
                }
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
            "None" });
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
            Page.Text = entity.SourceString;
            TypeComboBox.SelectedIndex = (int) entity.Type;
            SourceStringTextBox.Text = entity.SourceString;
            // todo: Tell the difference between a dictionary and a string match.
            MatchStringSourceTextBox.Text = entity.SourceString;
            if (entity.Type == EntityType.DictionaryWildcard || entity.Type == EntityType.SpecialWildcard) {
                MatchStringDictionarySourceComboBox.Show();
                if (entity.Type == EntityType.DictionaryWildcard) {
                    SetupComboBoxForDictionaries();
                    isSetup = true;
                    MatchStringDictionarySourceComboBox.SelectedIndex = Root.ParentWindow.ParentWindow.Data.Dictionaries.IndexOf(Root.ParentWindow.ParentWindow.Data.Dictionaries.First(d => d.GUID.ToLower() == entity.RawContents.ToLower()));
                }
                if (entity.Type == EntityType.SpecialWildcard) {
                    SetupComboBoxForWildcards(true);
                    MatchStringDictionarySourceComboBox.SelectedIndex = (int)SpecialWildcardTypeOperations.RawStringIdentifierToWildcardType(entity.RawContents);
                }
            }
            else
                MatchStringDictionarySourceComboBox.Hide();
            IsOutputEntityCheckBox.Checked = entity.IsOutputEntity;
            OutputEntitySlotComboBox.Items.Clear();
            foreach (OutputEntity outputEntity in Root.ParentWindow.Data.Outputs)
                OutputEntitySlotComboBox.Items.Add(outputEntity.Name);
            if (OutputEntitySlotComboBox.Items.Count == 0) {
                OutputEntitySlotComboBox.Items.Add("None");
            }
            OutputEntitySlotComboBox.SelectedIndex = 0;
            PartialThresholdTextBox.Text = entity.MatchThreshold.ToString();
            isSetup = false;
        }

        private void MatchStringDictionarySourceComboBoxOnSelectedIndexChanged(object sender, EventArgs e) {
            if (isSetup)
                return;

            switch ((EntityType) TypeComboBox.SelectedIndex) {
                case EntityType.None:
                    return;
                case EntityType.Optional:
                    return;
                case EntityType.PartialMatch:
                    return;
                case EntityType.DirectMatch:
                    return;
                case EntityType.Match:
                    return;
                case EntityType.Wildcard:
                    return;
                case EntityType.DictionaryWildcard:
                    Data.RawContents = Root.ParentWindow.ParentWindow.Data.Dictionaries[MatchStringDictionarySourceComboBox.SelectedIndex].GUID;
                    break;
                case EntityType.SpecialWildcard:
                    switch ((SpecialWildcardType) MatchStringDictionarySourceComboBox.SelectedIndex) {
                        case SpecialWildcardType.None:
                            Data.RawContents = SpecialWildcardTypeOperations.CodeNames.None;
                            break;
                        case SpecialWildcardType.Date:
                            Data.RawContents = SpecialWildcardTypeOperations.CodeNames.Date;
                            break;
                        case SpecialWildcardType.DateInterval:
                            Data.RawContents = SpecialWildcardTypeOperations.CodeNames.DateInterval;
                            break;
                        case SpecialWildcardType.Time:
                            Data.RawContents = SpecialWildcardTypeOperations.CodeNames.Time;
                            break;
                        case SpecialWildcardType.TimeInterval:
                            Data.RawContents = SpecialWildcardTypeOperations.CodeNames.TimeInterval;
                            break;
                        case SpecialWildcardType.DateTime:
                            Data.RawContents = SpecialWildcardTypeOperations.CodeNames.DateTime;
                            break;
                        case SpecialWildcardType.TimeSpan:
                            Data.RawContents = SpecialWildcardTypeOperations.CodeNames.TimeSpan;
                            break;
                        case SpecialWildcardType.Number:
                            Data.RawContents = SpecialWildcardTypeOperations.CodeNames.Number;
                            break;
                        case SpecialWildcardType.Ordinal:
                            Data.RawContents = SpecialWildcardTypeOperations.CodeNames.Ordinal;
                            break;
                        case SpecialWildcardType.Integer:
                            Data.RawContents = SpecialWildcardTypeOperations.CodeNames.Integer;
                            break;
                        case SpecialWildcardType.NumberSequence:
                            Data.RawContents = SpecialWildcardTypeOperations.CodeNames.NumberSequence;
                            break;
                        case SpecialWildcardType.FlightNumber:
                            Data.RawContents = SpecialWildcardTypeOperations.CodeNames.FlightNumber;
                            break;
                        case SpecialWildcardType.AnyUnit:
                            Data.RawContents = SpecialWildcardTypeOperations.CodeNames.AnyUnit;
                            break;
                        case SpecialWildcardType.AreaUnit:
                            Data.RawContents = SpecialWildcardTypeOperations.CodeNames.AreaUnit;
                            break;
                        case SpecialWildcardType.CurrencyUnit:
                            Data.RawContents = SpecialWildcardTypeOperations.CodeNames.CurrencyUnit;
                            break;
                        case SpecialWildcardType.LengthUnit:
                            Data.RawContents = SpecialWildcardTypeOperations.CodeNames.LengthUnit;
                            break;
                        case SpecialWildcardType.SpeedUnit:
                            Data.RawContents = SpecialWildcardTypeOperations.CodeNames.SpeedUnit;
                            break;
                        case SpecialWildcardType.VolumeUnit:
                            Data.RawContents = SpecialWildcardTypeOperations.CodeNames.VolumeUnit;
                            break;
                        case SpecialWildcardType.WeightUnit:
                            Data.RawContents = SpecialWildcardTypeOperations.CodeNames.WeightUnit;
                            break;
                        case SpecialWildcardType.InformationUnit:
                            Data.RawContents = SpecialWildcardTypeOperations.CodeNames.InformationUnit;
                            break;
                        case SpecialWildcardType.TemperatureUnit:
                            Data.RawContents = SpecialWildcardTypeOperations.CodeNames.TemperatureUnit;
                            break;
                        case SpecialWildcardType.DurationUnit:
                            Data.RawContents = SpecialWildcardTypeOperations.CodeNames.DurationUnit;
                            break;
                        case SpecialWildcardType.AgeUnit:
                            Data.RawContents = SpecialWildcardTypeOperations.CodeNames.AgeUnit;
                            break;
                        case SpecialWildcardType.CurrencyName:
                            Data.RawContents = SpecialWildcardTypeOperations.CodeNames.CurrencyName;
                            break;
                        case SpecialWildcardType.UnitName:
                            Data.RawContents = SpecialWildcardTypeOperations.CodeNames.UnitName;
                            break;
                        case SpecialWildcardType.Address:
                            Data.RawContents = SpecialWildcardTypeOperations.CodeNames.Address;
                            break;
                        // case SpecialWildcardType.StreetAddress:
                        //     Data.RawContents = SpecialWildcardTypeOperations.CodeNames.StreetAddress;
                        //     break;
                        case SpecialWildcardType.ZIPCode:
                            Data.RawContents = SpecialWildcardTypeOperations.CodeNames.ZIPCode;
                            break;
                        case SpecialWildcardType.Country:
                            Data.RawContents = SpecialWildcardTypeOperations.CodeNames.Country;
                            break;
                        case SpecialWildcardType.City:
                            Data.RawContents = SpecialWildcardTypeOperations.CodeNames.City;
                            break;
                        case SpecialWildcardType.District:
                            Data.RawContents = SpecialWildcardTypeOperations.CodeNames.District;
                            break;
                        case SpecialWildcardType.CountryCode:
                            Data.RawContents = SpecialWildcardTypeOperations.CodeNames.CountryCode;
                            break;
                        case SpecialWildcardType.Language:
                            Data.RawContents = SpecialWildcardTypeOperations.CodeNames.Language;
                            break;
                        case SpecialWildcardType.LanguageCode:
                            Data.RawContents = SpecialWildcardTypeOperations.CodeNames.LanguageCode;
                            break;
                        case SpecialWildcardType.Airport:
                            Data.RawContents = SpecialWildcardTypeOperations.CodeNames.Airport;
                            break;
                        case SpecialWildcardType.Coordinate:
                            Data.RawContents = SpecialWildcardTypeOperations.CodeNames.Coordinate;
                            break;
                        case SpecialWildcardType.CoordinateShortcode:
                            Data.RawContents = SpecialWildcardTypeOperations.CodeNames.CoordinateShortcode;
                            break;
                        case SpecialWildcardType.Email:
                            Data.RawContents = SpecialWildcardTypeOperations.CodeNames.Email;
                            break;
                        case SpecialWildcardType.PhoneNumber:
                            Data.RawContents = SpecialWildcardTypeOperations.CodeNames.PhoneNumber;
                            break;
                        case SpecialWildcardType.Color:
                            Data.RawContents = SpecialWildcardTypeOperations.CodeNames.Color;
                            break;
                        case SpecialWildcardType.URL:
                            Data.RawContents = SpecialWildcardTypeOperations.CodeNames.URL;
                            break;
                        default:
                            Data.RawContents = "S:#" + MatchStringDictionarySourceComboBox.SelectedIndex.ToString("000");
                            break;
                    }
                    break;
            }

            modified = true;
        }

        private void IsOutputEntityCheckBoxOnCheckedChanged(object sender, EventArgs e) {
            if (isSetup)
                return;

            Root.Modified = true;
            Data.IsOutputEntity = IsOutputEntityCheckBox.Checked;

            if (Data.IsOutputEntity) {
                OutputEntitySlotLabel.Show();
                OutputEntitySlotComboBox.Show();
                
            }
            if (!Data.IsOutputEntity) {
                OutputEntitySlotLabel.Hide();
                OutputEntitySlotComboBox.Hide();
                Data.OutputEntityGUID = "";
            }
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
                case EntityType.DictionaryWildcard:
                    MatchStringLabel.Visible = true;
                    MatchStringDictionarySourceComboBox.Visible = true;
                    MatchStringSourceTextBox.Visible = false;
                    SetupComboBoxForDictionaries();
                    break;
                case EntityType.SpecialWildcard:
                    MatchStringLabel.Visible = true;
                    MatchStringDictionarySourceComboBox.Visible = true;
                    MatchStringSourceTextBox.Visible = false;
                    SetupComboBoxForWildcards();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (isSetup)
                return;

            Root.Modified = true;
            Data.Type = (EntityType) TypeComboBox.SelectedIndex;
        }

        void SetupComboBoxForDictionaries() {
            List<object> DictionaryNames = new List<object>();
            foreach (Dictionary dictionary in Root.ParentWindow.ParentWindow.Data.Dictionaries)
                DictionaryNames.Add(dictionary.Name);
            MatchStringDictionarySourceComboBox.Items.Clear();
            MatchStringDictionarySourceComboBox.Items.AddRange(DictionaryNames.ToArray());
        }

        void SetupComboBoxForWildcards(bool isStillSettingUp = false) {
            if (!isStillSettingUp)
                isSetup = true;
            MatchStringDictionarySourceComboBox.Items.Clear();
            MatchStringDictionarySourceComboBox.Items.AddRange(new object[] {
                    SpecialWildcardTypeOperations.FullNames.None,
                    SpecialWildcardTypeOperations.FullNames.Date,
                    SpecialWildcardTypeOperations.FullNames.DateInterval,
                    SpecialWildcardTypeOperations.FullNames.Time,
                    SpecialWildcardTypeOperations.FullNames.TimeInterval,
                    SpecialWildcardTypeOperations.FullNames.DateTime,
                    SpecialWildcardTypeOperations.FullNames.TimeSpan,
                    SpecialWildcardTypeOperations.FullNames.Number,
                    SpecialWildcardTypeOperations.FullNames.Ordinal,
                    SpecialWildcardTypeOperations.FullNames.Integer,
                    SpecialWildcardTypeOperations.FullNames.NumberSequence,
                    SpecialWildcardTypeOperations.FullNames.FlightNumber,
                    SpecialWildcardTypeOperations.FullNames.AnyUnit,
                    SpecialWildcardTypeOperations.FullNames.AreaUnit,
                    SpecialWildcardTypeOperations.FullNames.CurrencyUnit,
                    SpecialWildcardTypeOperations.FullNames.LengthUnit,
                    SpecialWildcardTypeOperations.FullNames.SpeedUnit,
                    SpecialWildcardTypeOperations.FullNames.VolumeUnit,
                    SpecialWildcardTypeOperations.FullNames.WeightUnit,
                    SpecialWildcardTypeOperations.FullNames.InformationUnit,
                    SpecialWildcardTypeOperations.FullNames.TemperatureUnit,
                    SpecialWildcardTypeOperations.FullNames.DurationUnit,
                    SpecialWildcardTypeOperations.FullNames.AgeUnit,
                    SpecialWildcardTypeOperations.FullNames.CurrencyName,
                    SpecialWildcardTypeOperations.FullNames.UnitName,
                    SpecialWildcardTypeOperations.FullNames.Address,
                    SpecialWildcardTypeOperations.FullNames.StreetAddress,
                    SpecialWildcardTypeOperations.FullNames.ZIPCode,
                    SpecialWildcardTypeOperations.FullNames.Country,
                    SpecialWildcardTypeOperations.FullNames.City,
                    SpecialWildcardTypeOperations.FullNames.District,
                    SpecialWildcardTypeOperations.FullNames.CountryCode,
                    SpecialWildcardTypeOperations.FullNames.Language,
                    SpecialWildcardTypeOperations.FullNames.LanguageCode,
                    SpecialWildcardTypeOperations.FullNames.Airport,
                    SpecialWildcardTypeOperations.FullNames.Coordinate,
                    SpecialWildcardTypeOperations.FullNames.CoordinateShortcode,
                    SpecialWildcardTypeOperations.FullNames.Email,
                    SpecialWildcardTypeOperations.FullNames.PhoneNumber,
                    SpecialWildcardTypeOperations.FullNames.Color,
                    SpecialWildcardTypeOperations.FullNames.URL
                });
            if (!isStillSettingUp)
                isSetup = false;
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
            if (OutputEntitySlotComboBox.Items.Count == 1 && OutputEntitySlotComboBox.Items[0] == "None")
                return;

            Root.Modified = true;
            Data.OutputEntityGUID = Root.ParentWindow.Data.Outputs[OutputEntitySlotComboBox.SelectedIndex].GUID;
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

    public static class ShapeGenerationExtensions {
        public class SpecialWildcardDetectionResult {
            public SpecialWildcardType WildcardType;
            public string MatchString;
            public object MatchObject;
        }

        public class DictionaryDetectionResult {
            public string DictionaryGUID;
            public string WordGUID;
            public string MatchWord;
            public bool IsMatch;
        }

        public static bool IsAlphaNumeric(this string input) {
            return Regex.IsMatch(input, "^[a-zA-Z0-9]*$");
        }

        public static bool TrySpecialParse(this string input, out SpecialWildcardDetectionResult result) {
            result = null;
            return false;
        }

        public static bool TryDictionaryParse(this string input, List<Dictionary> dictionaries, out DictionaryDetectionResult result) {
            result = null;
            return false;
        }
    }
}
