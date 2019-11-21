using System;

namespace aytimothy.EIChatbot.Data {
    /// <summary>
    /// The Wildcard Entity is a pattern block that accepts any input other than nothing.
    /// </summary>
    [Serializable]
    public class WildcardEntity : Entity {
        /// <summary>
        /// Can nothing be in here (be empty) to be a positive match?
        /// </summary>
        public bool Optional;

        /// <summary>
        /// Creates a new Wildcard entity.
        /// </summary>
        public WildcardEntity() {
            Type = EntityType.Wildcard;
        }

        /// <summary>
        /// Creates a new Wildcard entity
        /// </summary>
        /// <param name="optional">Must it contain something?</param>
        public WildcardEntity(bool optional) {
            Type = EntityType.Wildcard;
            Optional = optional;
        }
    }
}