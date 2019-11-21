using System;

namespace aytimothy.EIChatbot.Data {
    /// <summary>
    /// The Wildcard Entity is a pattern block that accepts any input other than nothing.
    /// </summary>
    [Serializable]
    public class WildcardEntity : Entity {
        public WildcardEntity() {
            Type = EntityType.Wildcard;
        }
    }
}