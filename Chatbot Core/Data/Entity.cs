using System;

namespace aytimothy.EIChatbot.Data {
    /// <summary>
    /// An entity is the building block of a shape; it is a part of a sentence to be matched.
    /// This is the generic class that all shape types inherit from (contains common data).
    /// </summary>
    /// <remarks>
    /// The entity is a single part of a phrase (Shape) to be matched.
    /// It is like a single block out of the whole sentence to be matched.
    /// </remarks>
    [Serializable]
    public class Entity {
        /// <summary>
        /// What type of entity is this; what is the match criteria?
        /// </summary>
        public EntityType Type;
        /// <summary>
        /// This is the text to be matched for this block.
        /// </summary>
        public string RawContents;
        /// <summary>
        /// This is the original string for this block.
        /// </summary>
        public string SourceString;

        /// <summary>
        /// Is this entity an output? Does it return a value if its intent is the 
        /// </summary>
        public bool IsOutputEntity;
        /// <summary>
        /// Which output entity takes this value? (This matches OutputEntity.GUID)
        /// </summary>
        public string OutputEntityGUID; 
        /// <summary>
        /// The threshold for partial matches for this to be a valid match (requires that Type is 
        /// </summary>
        public float MatchThreshold;

        public Entity() {
            Type = EntityType.None;
        }
    }
}
