using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using aytimothy.EIChatbot.Data;
using aytimothy.EIChatbot.Editor;
using Newtonsoft.Json;

namespace aytimothy.EIChatbot {
    public class Chatbot {
        public ChatbotCore Core;

        public Chatbot() {
            Core = new ChatbotCore();
        }

        public void LoadDictionary (Dictionary Dictionary) {
            foreach (Dictionary dictionary in Core.Dictionaries)
                if (dictionary.GUID == Dictionary.GUID) {
                    Core.Dictionaries.Remove(dictionary);
                    break;
                }

            Core.Dictionaries.Add(Dictionary);
        }

        public void LoadIntent(Intent Intent) {
            foreach (Intent intent in Core.Intents)
                if (intent.GUID == Intent.GUID) {
                    Core.Intents.Remove(intent);
                    break;
                }

            Core.Intents.Add(Intent);
        }

        public void LoadKnowledgebase(Knowledgebase Knowledgebase) {
            foreach (Dictionary dictionary in Knowledgebase.Dictionaries)
                LoadDictionary(dictionary);
            foreach (Intent intent in Knowledgebase.Intents)
                LoadIntent(intent);
        }

        public void LoadKnowledgebase(string KnowledgebasePath) {
            if (!File.Exists(KnowledgebasePath))
                throw new FileNotFoundException();

            string rawData = File.ReadAllText(KnowledgebasePath);
            Knowledgebase knowledgebase = JsonConvert.DeserializeObject<Knowledgebase>(rawData);
            LoadKnowledgebase(knowledgebase);
        }

        public ChatbotResponse Query(ChatbotRequest Request) {
            return Core.Query(Request);
        }

        public ChatbotResponse Query(string Request, bool returnDebugInformation = false) {
            ChatbotRequest request = new ChatbotRequest();
            request.PassthroughData = null;
            request.Request = Request;
            request.ReturnDebugInformation = returnDebugInformation;
            request.Timestamp = DateTime.Now;
            request.UUID = EditorUtils.ByteArrayToHexString(EditorUtils.GenerateNextGUID());
            return Query(request);
        }
    }
}
