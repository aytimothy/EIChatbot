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
        public List<Dictionary> Dictionaries = new List<Dictionary>();

        /// <summary>
        /// All the intents contained in this knowledge-base.
        /// </summary>
        public List<Intent> Intents = new List<Intent>();

        /// <summary>
        /// This is the fallback intent for when no intents are matched.
        /// </summary>
        public Intent FallbackIntent;

        /// <summary>
        /// Searches the knowledgebase for a dictionary structure with the specified name or GUID.
        /// </summary>
        /// <param name="searchString">The name/GUID of the dictionary to look for.</param>
        /// <param name="exactMatch">Should we look for an exact match?</param>
        /// <returns>The first dictionary fitting the citeria, or null if nothing is found.</returns>
        public Dictionary FindDictionary(string searchString, bool exactMatch = true) {
            for (int i = 0; i < Dictionaries.Count; i++) {
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
            for (int i = 0; i < Dictionaries.Count; i++) {
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
    }
}
