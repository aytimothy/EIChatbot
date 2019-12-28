using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aytimothy.EIChatbot.Data {
    [Serializable]
    public class ChatbotRequest {
        public string UUID;
        public DateTime Timestamp;
        public string Request;
        public Dictionary<string, string> PassthroughData;
        public bool ReturnDebugInformation;
    }
}
