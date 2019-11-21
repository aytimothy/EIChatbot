using System;

namespace aytimothy.EIChatbot.Data {
    [Serializable]
    public class MatchEntity : Entity {
        public MatchEntity() {
            Type = EntityType.Match;
        }

        public MatchEntity(string shape) {
            Type = EntityType.Match;
            RawContents = shape;
        }
    }
}