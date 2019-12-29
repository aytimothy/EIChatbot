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

            List<ShapeIdentificationResult> identification = new List<ShapeIdentificationResult>();
            foreach (Intent intent in Intents) {
                foreach (Shape shape in intent.Shapes) {
                    ShapeIdentificationResult result = Evaluate(shape, request.Request);
                    result.IntentUUID = intent.GUID;
                    result.ShapeIndex = Array.IndexOf(intent.Shapes, shape);
                    result.ShapeUUID = shape.GUID;
                    identification.Add(result);
                }
            }

            float threshold = 0.8f;
            // for all results, cull anything less than the threshold.
            // return the most confident result

            DateTime endTime = DateTime.Now;
            TimeSpan processingTime = endTime - startTime;
            response.ProcessingTime = processingTime;
            return response;

            ShapeIdentificationResult Evaluate(Shape shape, string text) {
                ShapeIdentificationResult result = new ShapeIdentificationResult();
                List<EntityIdentificationResult> checks = new List<EntityIdentificationResult>();
                float confidence = 0f;
                ShapeIdentificationStatus status = ShapeIdentificationStatus.None;

                string[] splitString = new string[0];
                string[] matchString = new string[0];
                switch (shape.Language) {
                    case Language.None:
                        goto case Language.English;
                    case Language.English:
                        splitString = text.Split(' ');
                        matchString = new string[splitString.Length];
                        for (int i = 0; i < splitString.Length; i++)
                            matchString[i] = splitString[i];

                        // todo: Complain if there are multiple sentences...
                        // or should split them up?
                        break;
                    case Language.Chinese:
                        throw new NotImplementedException();
                    case Language.Japanese:
                        throw new NotImplementedException();
                    case Language.German:
                        throw new NotImplementedException();
                    default:
                        throw new NotSupportedException();
                }

                int shapeFirstFailed = 0;
                int shapeFirstPartial = 0;
                int shapeFirstMatched = 0;
                int splitStringIndex = 0;
                // look shape first
                for (int entityPairIndex = 0; entityPairIndex < shape.Entities.Length; entityPairIndex++) {
                    if (entityPairIndex == 0) {

                    }

                    if (entityPairIndex >= 0) {

                    }
                }

                int textFirstFailed = 0;
                int textFirstPartial = 0;
                int textFirstMatched = 0;
                splitStringIndex = 0;
                // look text first
                for (int entityPairIndex = 0; entityPairIndex < shape.Entities.Length; entityPairIndex++) {
                    
                }

                result.EntityChecks = checks.ToArray();
                result.Result = status;
                result.Confidence = confidence;
                return result;
            }
        }

        public ChatbotResponse QueryWithoutDebugInfo(ChatbotRequest request) {
            // todo: Splice debug stuff out of the algorithm above.
            return QueryWithDebugInfo(request);
        }

        public ref Dictionary FindDictionary(string UUID) {
            throw new NotImplementedException();
        }

        public ref Dictionary FindDictionaryWith(string Word) {
            throw new NotImplementedException();
        }

        public bool DictionaryContains(Dictionary Dictionary, string Word) {
            throw new NotImplementedException();
        }

        public ref Intent FindIntent(string UUID) {
            throw new NotImplementedException();
        }

        public ref Shape FindShape(string UUID) {
            throw new NotImplementedException();
        }
    }
}
