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
        public Shape[] Shapes;

        public Intent(string intentID, string intentString) {
            throw new NotImplementedException();
        }
    }
}
