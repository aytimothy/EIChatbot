using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aytimothy.EIChatbot.Data
{
    public class ChatbotResponse {
        public ChatbotRequest Request;

        public string UUID;
        public DateTime Timestamp;
        public TimeSpan ProcessingTime;
        public string Response;
        public Dictionary<string, string> PassthroughData;
        public Dictionary<string, OutputEntityResult> OutputEntities;

        public ChatbotDebugInformation DebugInformation;
    }
}
