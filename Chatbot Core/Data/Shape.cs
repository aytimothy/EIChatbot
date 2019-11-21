using System;

namespace aytimothy.EIChatbot.Data {
    [Serializable]
    public class Shape : ChatbotData {
        public string ShapeString;
        public Language Language;
        public Entity[] Entities;
    }
}
