using System;

namespace aytimothy.EIChatbot.Data {
    /// <summary>
    /// 
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
