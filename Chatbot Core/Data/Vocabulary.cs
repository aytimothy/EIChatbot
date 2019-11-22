using System;

namespace aytimothy.EIChatbot.Data { 
    /// <summary>
    /// Vocabularies are a set of words that mean something.
    /// </summary>
    /// <example>
    /// If you were referring to "old lady", you could refer to her as a "hag", "oma" or "grandma" (though those are more specific terminology).
    /// The chatbot will then make inference that:
    /// "My oma is very nice." and "My grandma is very nice" are the same sentences.
    /// </example>
    [Serializable]
    public class Vocabulary : ChatbotData {
        public string Meaning;
        public string[] Synonyms;
    }
}
