using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aytimothy.EIChatbot.Data {
    public class ChatbotDebugInformation {
        public Dictionary<string, float> IntentIdentificationConfidence;
        public ShapeIdentificationResult[] ShapeIdentificationResults;
    }

    public class ShapeIdentificationResult {
        public string ShapeUUID;
        public int ShapeIndex;
        public float Confidence;
        public ShapeIdentificationStatus Result;
        public EntityIdentificationResult[] EntityChecks;
    }

    public class EntityIdentificationResult {
        public int EntityIndex;
        public float Match;
        public string[] MatchAttempt;
        public bool Success;
    }

    public enum ShapeIdentificationStatus {
        None,
        Failed,
        SuccessMatch,
        SuccessNoMatch,
    }
}
