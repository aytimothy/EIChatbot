﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace aytimothy.EIChatbot.Data {
    [Serializable]
    public class OptionalEntity : Entity {
        public OptionalEntity() {
            Type = EntityType.Optional;
        }

        public OptionalEntity(string shape) {
            Type = EntityType.Optional;
            RawContents = shape;
        }
    }
}
