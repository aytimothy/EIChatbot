using System;

namespace aytimothy.EIChatbot.Data {
    [Serializable]
    public class DictionaryEntity : Entity {
        public string VocabularyUUID;

        public DictionaryEntity() {
            Type = EntityType.DictionaryWildcard;
        }

        public DictionaryEntity(string guid) {
            Type = EntityType.DictionaryWildcard;
            VocabularyUUID = guid;
        }

        public Dictionary GetDictionary(Knowledgebase knowledgebase) {
            return knowledgebase.FindDictionary(VocabularyUUID, true);
        }
    }
}