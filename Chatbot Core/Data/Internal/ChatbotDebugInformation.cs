using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aytimothy.EIChatbot.Data {
    /// <summary>
    /// A container for storing information about all the comparisons with all intents.
    /// </summary>
    public class ChatbotDebugInformation {
        public ShapeIdentificationResult[] ShapeIdentificationResults;
    }

    /// <summary>
    /// A container for storing information about an intent's processing.
    /// </summary>
    public class ShapeIdentificationResult {
        /// <summary>
        /// The UUID Intent the compared Shape belongs to. (Should match Intent.GUID)
        /// </summary>
        public string IntentUUID;
        /// <summary>
        /// The UUID of the Shape that is compared belongs to. (Should match Intent.Shapes[X].GUID
        /// </summary>
        public string ShapeUUID;
        /// <summary>
        /// The index of the Shape in the Intent's Shapes array.
        /// </summary>
        public int ShapeIndex;
        /// <summary>
        /// "How" confident the algorithm thinks the input is this intent?
        /// </summary>
        public float Confidence;
        /// <summary>
        /// The yes/no this is/isn't Intent ___________
        /// </summary>
        public ShapeIdentificationStatus Result;
        /// <summary>
        /// The results of each individual entity's comparison checks.
        /// </summary>
        public EntityIdentificationResult[] EntityChecks;
        /// <summary>
        /// The data from the output entities...
        /// </summary>
        public Dictionary<string, OutputEntityResult> OutputEntities;
    }

    /// <summary>
    /// A container for storing information about the breakdown of the intent processing (in Entity bits)
    /// </summary>
    public class EntityIdentificationResult {
        /// <summary>
        /// The index of the Entity in the Shape's Shape.Entities array.
        /// </summary>
        public int EntityIndex;
        /// <summary>
        /// How 'matched' is this intent with a word block?
        /// </summary>
        public float Match;
        /// <summary>
        /// The formatted data for SpecialWilcard entities.
        /// </summary>
        public Dictionary<string, string> MatchOutput = new Dictionary<string, string>();
        /// <summary>
        /// Was there a match?
        /// </summary>
        public bool Success;
    }

    public enum ShapeIdentificationStatus {
        None,
        Failed,
        SuccessMatch,
        SuccessNoMatch,
    }
}
