using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace aytimothy.EIChatbot.Debugger
{
    public class ChatLog {
        public LogType Type;
        public DateTime Timestamp;
        public string Message;

        public object Data;
    }

    public enum LogType {
        Request,
        Response,
        Message
    }
}
