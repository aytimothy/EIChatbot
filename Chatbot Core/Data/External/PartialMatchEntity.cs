using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace aytimothy.EIChatbot.Data {
    [Serializable]
    public class PartialMatchEntity : Entity {
        public float Threshold;

        public PartialMatchEntity() {
            Type = EntityType.PartialMatch;
        }

        public PartialMatchEntity(string shape) {
            Type = EntityType.PartialMatch;
            RawContents = shape;
        }

        public PartialMatchEntity(string shape, float threshold) {
            Type = EntityType.PartialMatch;
            RawContents = shape;
            Threshold = 0.5f;
        }
    }
}
