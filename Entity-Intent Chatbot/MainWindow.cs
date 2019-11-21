using System;
using System.Windows.Forms;

namespace aytimothy.EIChatbot.Editor {
    public partial class MainWindow : Form, ILocalizedForm {
        public MainWindow() {
            InitializeComponent();
            InitializeLocalization();
        }

        public void InitializeLocalization() {
            TitleLabel.Text = Localization.English.MainWindow_TitleLabelText;
            NewButton.Text = Localization.English.MainWindow_NewButtonText;
            OpenButton.Text = Localization.English.MainWindow_OpenButtonText;
            PreferencesButton.Text = Localization.English.MainWindow_PreferencesButtonText;
            QuitButton.Text = Localization.English.MainWindow_QuitButtonText;
            AboutLinkLabel.Text = Localization.English.MainWindow_AboutLinkLabelText;
        }

        private void NewButton_Click(object sender, EventArgs e) {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            DialogResult dialogResult = saveFileDialog.ShowDialog();

            throw new NotImplementedException();
        }

        private void OpenButton_Click(object sender, EventArgs e) {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            DialogResult dialogResult = openFileDialog.ShowDialog();

            throw new NotImplementedException();
        }

        private void PreferencesButton_Click(object sender, EventArgs e) {
            throw new NotImplementedException();
        }

        private void QuitButton_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void AboutLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            AboutWindow aboutWindow = new AboutWindow(this);
            aboutWindow.Show();
            Hide();
        }
    }
}
