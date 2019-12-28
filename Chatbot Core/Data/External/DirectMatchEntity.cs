using System;

namespace aytimothy.EIChatbot.Data {
    /// <summary>
    /// This is an entity where the contents has to be exactly the same.
    /// Unlike the regular MatchEntity, this checks character by character and ignores language sematics.
    /// So, if a word is separated by two spaces, there MUST be two spaces to match. (Whereas in English, it doesn't matter how many spaces, as long as it's greater than one)
    /// That and Chinese/Japanese Spaces (Full-width) != English Spaces (Half-width)
    /// </summary>
    [Serializable]
    public class DirectMatchEntity : Entity {
        public bool CaseSensitive;

        public DirectMatchEntity() {
            Type = EntityType.DirectMatch;
        }

        public DirectMatchEntity(string shape) {
            Type = EntityType.DirectMatch;
            RawContents = shape;
            CaseSensitive = false;
        }

        public DirectMatchEntity(string shape, bool caseSensitive) {
            Type = EntityType.DirectMatch;
            RawContents = shape;
            CaseSensitive = caseSensitive;
        }
    }
}
