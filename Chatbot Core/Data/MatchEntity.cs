using System;

namespace aytimothy.EIChatbot.Data {
    /// <summary>
    /// This is an entity where the words have to match up.
    /// Unlike DirectMatchEntity, language semantics do come into play here.
    /// </summary>
    [Serializable]
    public class MatchEntity : Entity {
        /// <summary>
        /// Creates a new MatchEntity with no data.
        /// </summary>
        public MatchEntity() {
            Type = EntityType.Match;
        }

        /// <summary>
        /// Creates a new MatchEntity looking for the specific word or phrase.
        /// </summary>
        /// <param name="shape">The text to look for.</param>
        public MatchEntity(string shape) {
            Type = EntityType.Match;
            RawContents = shape;
        }
    }
}