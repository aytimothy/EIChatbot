using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using aytimothy.EIChatbot.Data;
using aytimothy.EIChatbot.Editor;

namespace aytimothy.EIChatbot
{
    public class ChatbotCore {
        public List<Dictionary> Dictionaries = new List<Dictionary>();
        public List<Intent> Intents = new List<Intent>();

        public ChatbotResponse Query(ChatbotRequest request) {
            if (request.ReturnDebugInformation)
                return QueryWithDebugInfo(request);
            if (!request.ReturnDebugInformation)
                return QueryWithoutDebugInfo(request);
            throw new NotSupportedException();
        }

        public ChatbotResponse QueryWithDebugInfo(ChatbotRequest request) {
            ChatbotResponse response = new ChatbotResponse();
            response.DebugInformation = new ChatbotDebugInformation();
            response.OutputEntities = new Dictionary<string, OutputEntityResult>();
            response.PassthroughData = new Dictionary<string, string>();
            foreach (string ptdKey in request.PassthroughData.Keys)
                response.PassthroughData[ptdKey] = request.PassthroughData[ptdKey];
            response.Request = request;
            response.UUID = EditorUtils.ByteArrayToHexString(EditorUtils.GenerateNextUUID());
            DateTime startTime = DateTime.Now;
            response.Timestamp = startTime;

            // todo: Process

            DateTime endTime = DateTime.Now;
            TimeSpan processingTime = endTime - startTime;
            response.ProcessingTime = processingTime;
            return response;
        }

        public ChatbotResponse QueryWithoutDebugInfo(ChatbotRequest request) {
            // todo: Splice debug stuff out of the algorithm above.
            return QueryWithDebugInfo(request);
        }
    }
}
