using System.Diagnostics;
using System.Windows.Forms;

namespace aytimothy.EIChatbot.Editor {
    public partial class AboutWindow : Form, ILocalizedForm {
        private MainWindow parentWindow;

        public AboutWindow(MainWindow parent) {
            InitializeComponent();
            InitializeLocalization();

            parentWindow = parent;
        }

        public void InitializeLocalization() {
            TitleLabel.Text = Localization.English.AboutWindow_TitleLabelText;
            VersionLabel.Text = Application.ProductVersion;
            Line1Label.Text = Localization.English.AboutWindow_Line1LabelText;
            Line2Label.Text = Localization.English.AboutWindow_Line2LabelText;
            ParagraphLabel.Text = Localization.English.AboutWindow_ParagraphLabelText;
            Line3Label.Text = Localization.English.AboutWindow_Line3LabelText;
            LinkLabel1.Text = Localization.English.AboutWindow_LinkLabelText;
            CloseLabel.Text = Localization.English.AboutWindow_CloseLabelText;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            ProcessStartInfo bpsi = new ProcessStartInfo("https://aytimothy.xyz/projects/eichatbot");
            Process.Start(bpsi);
        }

        private void AboutWindow_FormClosing(object sender, FormClosingEventArgs e) {
            parentWindow.Show();
        }

        private void CloseLabel_Click(object sender, System.EventArgs e) {
            Close();
        }

        private void Line3Label_Click(object sender, System.EventArgs e) {
            Close();
        }

        private void ParagraphLabel_Click(object sender, System.EventArgs e) {
            Close();
        }

        private void Line2Label_Click(object sender, System.EventArgs e) {
            Close();
        }

        private void Line1Label_Click(object sender, System.EventArgs e) {
            Close();
        }

        private void VersionLabel_Click(object sender, System.EventArgs e) {
            Close();
        }

        private void TitleLabel_Click(object sender, System.EventArgs e) {
            Close();
        }

        private void AboutWindow_Click(object sender, System.EventArgs e) {
            Close();
        }
    }
}
