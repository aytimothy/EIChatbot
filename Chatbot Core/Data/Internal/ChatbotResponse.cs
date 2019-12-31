using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aytimothy.EIChatbot.Data
{
    public class ChatbotResponse {
        /// <summary>
        /// The original request.
        /// </summary>
        public ChatbotRequest Request;

        /// <summary>
        /// A universal identifier for this response.
        /// </summary>
        public string UUID;
        /// <summary>
        /// The timestamp at which this response was created.
        /// </summary>
        public DateTime Timestamp;
        /// <summary>
        /// How long did the engine take to generate this response?
        /// </summary>
        public TimeSpan ProcessingTime;
        /// <summary>
        /// The raw text response for this request.
        /// </summary>
        /// <remarks>
        /// Not Implemented Yet...
        /// </remarks>
        public string Response;
        /// <summary>
        /// The Shape that this request matched to.
        /// </summary>
        public string ShapeUUID;
        /// <summary>
        /// The entity that this request matched to.
        /// </summary>
        public string EntityUUID;
        /// <summary>
        /// Passthrough data from the request.
        /// </summary>
        public Dictionary<string, string> PassthroughData;
        /// <summary>
        /// OutputEntity values from the request.
        /// </summary>
        /// <remarks>
        /// These are sorted by the GUID of the output entity.
        /// </remarks>
        public Dictionary<string, OutputEntityResult> OutputEntities;

        /// <summary>
        /// Any calculation results. Null if it is not in debug mode.
        /// </summary>
        public ChatbotDebugInformation DebugInformation;
    }
}
