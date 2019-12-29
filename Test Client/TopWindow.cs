using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using aytimothy.EIChatbot.Data;

namespace aytimothy.EIChatbot.Debugger
{
    public partial class TopWindow : Form {
        public Chatbot chatbot = new Chatbot();

        public List<ChatLog> Log = new List<ChatLog>();

        public TopWindow() {
            InitializeComponent();
        }

        private void OutputDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            
        }

        private void InputTextBox_TextChanged(object sender, EventArgs e) {
            // do zip.
        }

        private void OpenAgentToolStripMenuItem_Click(object sender, EventArgs e) {
            OpenFileDialog.Filter = "";
            DialogResult dialogResult = OpenFileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
                chatbot.LoadKnowledgebase(OpenFileDialog.FileName);
        }

        private void SaveOutputToolStripMenuItem_Click(object sender, EventArgs e) {
            MessageBox.Show("Not Implemented Yet...", "Error");
        }

        private void QuitToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void SubmitButton_Click(object sender, EventArgs e) {
            string message = InputTextBox.Text;
            InputTextBox.Text = "";
            ChatbotRequest request = new ChatbotRequest();
            ChatbotResponse response = chatbot.Query(request);

            LogRequest(request);
            LogResponse(response);

            void LogRequest(ChatbotRequest _request) {
                ChatLog log = new ChatLog();
                log.Data = _request;
                log.Message = _request.Request;
                log.Timestamp = _request.Timestamp;
                log.Type = LogType.Request;
                Log.Add(log);

                OutputDataGridView.Rows.Add(new object[] { log.Timestamp.ToShortDateString() + " " + log.Timestamp.ToShortTimeString(), "Request", log.Message });
            }

            void LogResponse(ChatbotResponse _response) {
                ChatLog log = new ChatLog();
                log.Data = _response;
                log.Message = _response.Response;
                log.Timestamp = _response.Timestamp;
                log.Type = LogType.Response;
                Log.Add(log);

                OutputDataGridView.Rows.Add(new object[] { log.Timestamp.ToShortDateString() + " " + log.Timestamp.ToShortTimeString(), "Response", log.Message });
            }
        }
    }
}
