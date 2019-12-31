using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using aytimothy.EIChatbot.Data;

namespace aytimothy.EIChatbot {
    /// <summary>
    /// Initializes an asynchronous instance of the chatbot.
    /// </summary>
    public class ChatbotAsync {
        public EventHandler<LoadEvent> OnItemLoad;
        public EventHandler<ResponseEvent> OnResponse;

        public ChatbotCore Core;

        public ChatbotAsync () {

        }

        public void LoadDictionary(Dictionary Dictionary) {
            throw new NotImplementedException();
        }

        public void LoadIntent(Intent Intent) {
            throw new NotImplementedException();
        }

        public void LoadKnowledgebase(Knowledgebase Knowledgebase) {
            throw new NotImplementedException();
        }

        public void LoadKnowledgebase(string KnowledgebasePath) {
            throw new NotImplementedException();
        }

        public void Query(ChatbotRequest Request) {
            throw new NotImplementedException();
        }

        public void Query(string Request) {
            throw new NotImplementedException();
        }
    }

    public class LoadEvent : EventArgs {
        public string CallbackValue;
    }

    public class ResponseEvent : EventArgs {
        public ChatbotResponse Result;
    }
}
