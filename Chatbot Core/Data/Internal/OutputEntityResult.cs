using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace aytimothy.EIChatbot.Data {
    [Serializable]
    public class OutputEntityResult {
        public string OutputEntityUUID;
        public string OutputEntityName;
        public bool HasResult;
        public Dictionary<string, string> Results;
    }
}
