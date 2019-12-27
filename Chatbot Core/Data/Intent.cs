using System;
using System.CodeDom.Compiler;
using System.Globalization;

// Kan, busy driver, departing BP around 9:30, everyday
namespace aytimothy.EIChatbot.Data {
    /// <summary>
    /// An intent is a command or the end meaning that a sentence provides.
    /// </summary>
    [Serializable]
    public class Intent : ChatbotData {
        /// <summary>
        /// All domain-less intents are classified into this namespace.
        /// </summary>
        public const string RootDomain = "global";

        /// <summary>
        /// This is a alphanumeric identifier for this intent.
        /// </summary>
        public string IntentID;
        /// <summary>
        /// This is the grouping domain of this intent.
        /// </summary>
        public string IntentDomain;
        /// <summary>
        /// Returns the full domain string of this intent.
        /// </summary>
        public string IntentFullID {
            get {
                if (String.IsNullOrEmpty(IntentDomain))
                    return RootDomain + "." + IntentID;
                return IntentDomain + "." + IntentID;
            }
        }

        /// <summary>
        /// This is a list of text patterns that fits this intent.
        /// </summary>
        public Shape[] Shapes = new Shape[0];
        /// <summary>
        /// This is a list of entities shared by all the shapes.
        /// </summary>
        public OutputEntity[] Outputs = new OutputEntity[0];

        public Intent() {

        }

        /// <summary>
        /// Creates a new empty intent.
        /// </summary>
        /// <remarks>
        /// For proper intent creation, you'll want to use ChatbotEditor's CreateIntent().
        /// This just creates a bare-bones structure without any processing.
        /// </remarks>
        /// <param name="intentID">The domain ID of the intent you wish to create.</param>
        /// <param name="intentString">The match string of the intent you wish to create.</param>
        public Intent(string intentID, string intentString) {
            string[] intentSplit = intentID.Split('.');
            if (intentSplit.Length == 1) {
                IntentID = intentSplit[0];
                IntentDomain = "";
            }
            if (intentSplit.Length > 1) {
                IntentID = intentSplit[intentSplit.Length - 1];
                IntentDomain = String.Join(".", intentSplit, 0, intentSplit.Length - 1);
            }
        }
    }
}
