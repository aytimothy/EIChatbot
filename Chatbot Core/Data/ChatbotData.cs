using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace aytimothy.EIChatbot.Data {
    /// <summary>
    /// This is the base class relating to anything that is agent-specific data.
    /// </summary>
    [Serializable]
    public abstract class ChatbotData {
        /// <summary>
        /// The GUID is used to identify unique information blocks. This is mainly used for debugging.
        /// </summary>
        public string GUID;
    }
}
