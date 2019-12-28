using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace aytimothy.EIChatbot.Data {
    /// <summary>
    /// A list of languages the chatbot supports.
    /// </summary>
    public enum Language {
        /// <summary>
        /// Null value; basically makes code do nothing or spit errors. Don't use this ever.
        /// </summary>
        None,
        /// <summary>
        /// The English Language
        /// </summary>
        /// <example>
        /// Hello World!
        /// </example>
        /// <remarks>
        /// Wait, aren't all the comments written in English?
        /// </remarks>
        English,
        /// <summary>
        /// The Chinese Language. Refers to Standard Singaporean Mandarin.
        /// </summary>
        /// <example>
        /// 你好世界！
        /// </example>
        Chinese,
        /// <summary>
        /// The Japanese Language. Very obviously spoken in Japan.
        /// </summary>
        /// <example>
        /// こんにちは世界！
        /// </example>
        Japanese,
        /// <summary>
        /// The German Language. Refers to central germany German; AKA. the German everyone knows.
        /// </summary>
        /// <example>
        /// Hallo Welt!
        /// </example>
        German
    }

    public enum ExperimentalLanguages {

    }
}
