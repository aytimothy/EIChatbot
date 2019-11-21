using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace aytimothy.EIChatbot.Data {
    /// <summary>
    /// Also known as an 'agent', it is basically all the phrases and things that the chatbot can understand.
    /// </summary>
    [Serializable]
    public class Knowledgebase : ChatbotData {
        /// <summary>
        /// The name of this knowledge-base.
        /// </summary>
        public string AgentName;
        /// <summary>
        /// The name of this knowledge-base.
        /// </summary>
        /// <remarks>
        /// Just an alias of AgentName for consistent naming.
        /// </remarks>
        public string Name => AgentName;

        /// <summary>
        /// (Metadata) This is the author who wrote the knowledge-base.
        /// </summary>
        public string Author;
        /// <summary>
        /// (Metadata) This is a comment field for the knowledge-base.
        /// </summary>
        public string Description;

        /// <summary>
        /// All the dictionaries contained in this knowledge-base.
        /// </summary>
        public Dictionary[] Dictionaries;
        /// <summary>
        /// All the intents contained in this knowledge-base.
        /// </summary>
        public Intent[] Intents;

        /// <summary>
        /// Searches the knowledgebase for a dictionary structure with the specified name or GUID.
        /// </summary>
        /// <param name="searchString">The name/GUID of the dictionary to look for.</param>
        /// <param name="exactMatch">Should we look for an exact match?</param>
        /// <returns>The first dictionary fitting the citeria, or null if nothing is found.</returns>
        public Dictionary FindDictionary(string searchString, bool exactMatch = true) {
            for (int i = 0; i < Dictionaries.Length; i++) {
                Dictionary dictionary = Dictionaries[i];
                if (exactMatch) {
                    if (dictionary.Name == searchString)
                        return dictionary;
                    if (dictionary.GUID == searchString)
                        return dictionary;
                }
                if (!exactMatch) {
                    if (dictionary.Name.ToLower().Contains(searchString.ToLower()))
                        return dictionary;
                    if (dictionary.GUID.ToUpper().Contains(searchString.ToUpper()))
                        return dictionary;
                }
            }

            return null;
        }

        /// <summary>
        /// Searches the knowledgebase for dictionary structures fitting the specified search string.
        /// </summary>
        /// <param name="searchString">The partial name or GUID to search for.</param>
        /// <returns>All search results. An empty array if nothing is found.</returns>
        public Dictionary[] FindDictionaries(string searchString) {
            List<Dictionary> results = new List<Dictionary>();
            for (int i = 0; i < Dictionaries.Length; i++) {
                Dictionary dictionary = Dictionaries[i];
                if (dictionary.Name.ToLower().Contains(searchString.ToLower())) {
                    results.Add(dictionary);
                    continue;
                }
                if (dictionary.GUID.ToUpper().Contains(searchString.ToUpper()))
                    results.Add(dictionary);
            }

            return results.ToArray();
        }

        /// <summary>
        /// Searches the knowledgebase for an intent structure fitting the specified name or GUID.
        /// </summary>
        /// <param name="searchString">The ID/GUID of the intent to search for.</param>
        /// <param name="exactMatch">Should we look for an exact match?</param>
        /// <returns>The first intent fitting the citeria.</returns>
        public Intent FindIntent(string searchString, bool exactMatch = true) {
            for (int i = 0; i < Intents.Length; i++) {
                Intent intent = Intents[i];
                if (exactMatch) {
                    if (intent.IntentFullID == searchString)
                        return intent;
                    if (intent.GUID == searchString)
                        return intent;
                }
                if (!exactMatch) {
                    if (intent.IntentFullID.ToLower().Contains(searchString.ToLower()))
                        return intent;
                    if (intent.GUID.ToUpper().Contains(searchString.ToUpper()))
                        return intent;
                }
            }

            return null;
        }

        /// <summary>
        /// Searches the knowledgebase for intent structures fitting the specified search string.
        /// </summary>
        /// <param name="searchString">The partial ID or GUID to search for.</param>
        /// <returns>All search results. An empty array if nothing is found.</returns>
        public Intent[] FindIntents(string searchString) {
            List<Intent> results = new List<Intent>();
            for (int i = 0; i < Intents.Length; i++) {
                Intent intent = Intents[i];
                if (intent.IntentFullID.ToLower().Contains(searchString.ToLower())) {
                    results.Add(intent);
                    continue;
                }
                if (intent.GUID.ToUpper().Contains(searchString.ToUpper()))
                    results.Add(intent);
            }

            return results.ToArray();
        }

        /// <summary>
        /// Searches the knowledgebase for vocabulary structures fitting the specified search string.
        /// </summary>
        /// <param name="GUID">The GUID of the vocabulary to find.</param>
        /// <returns>The vocabulary entry, if it exists.</returns>
        public Vocabulary FindVocabulary(string GUID) {
            foreach (Dictionary dictionary in Dictionaries)
                foreach (Vocabulary vocabulary in dictionary.Vocabulary)
                    if (vocabulary.GUID.ToUpper() == GUID.ToUpper())
                        return vocabulary;
            return null;
        }
    }
}
