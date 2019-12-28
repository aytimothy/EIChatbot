using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace aytimothy.EIChatbot.Data {
    /// <summary>
    /// Represents a dictionary of words for vocabulary analysis.
    /// </summary>
    /// <remarks>
    /// Not to be confused with a dictionary (an array where the indices are not numbers but objects).
    /// </remarks>
    [Serializable]
    public class Dictionary : ChatbotData {
        /// <summary>
        /// The name of this collection of vocabulary words. (Metadata)
        /// </summary>
        public string Name;
        /// <summary>
        /// A description of this collection of vocabulary words. (Metadata)
        /// </summary>
        public string Description;

        /// <summary>
        /// The actual collection of vocabulary words.
        /// </summary>
        public Vocabulary[] Vocabulary = new Vocabulary[0];
    }
}
