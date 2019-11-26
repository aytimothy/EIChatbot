using System;

namespace aytimothy.EIChatbot.Data {
    [Serializable]
    public class Shape : ChatbotData {
        public string ShapeString;
        public Language Language;
        public Entity[] Entities = new Entity[0];

        public Shape(string text) {
            ShapeString = text;
        }

        public Shape(string text, Language language) {
            ShapeString = text;
            Language = language;
        }
    }
}
