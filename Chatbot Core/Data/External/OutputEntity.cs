using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aytimothy.EIChatbot.Data {
    public class OutputEntity : ChatbotData {
        public string Name;

        public OutputEntity() {
            GUID = "";
            Name = "";
        }

        public OutputEntity(string name) {
            GUID = "";
            Name = name;
        }

        public OutputEntity(string name, string guid) {
            GUID = guid;
            Name = name;
        }
    }
}
