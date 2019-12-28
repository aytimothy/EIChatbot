using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace aytimothy.EIChatbot.Data {
    /// <summary>
    /// Types of entities.
    /// </summary>
    public enum EntityType {
        /// <summary>
        /// This block is nothing; just ignore it when pattern matching.
        /// </summary>
        None,
        /// <summary>
        /// This block is not calculated in the match score when pattern matching.
        /// </summary>
        Optional,
        /// <summary>
        /// This block counts if some of the characters above a threshold matches.
        /// </summary>
        PartialMatch,
        /// <summary>
        /// The block must match exactly. Letter for letter, word for word, capitalization, etc.
        /// </summary>
        /// <remarks>
        /// This is invariant of cultures/languages. If you have a space in there, a space IS required to match.
        /// For example, if you put a space in there and some languages ignore spaces, this will fail if that space is not there.
        /// </remarks>
        DirectMatch,
        /// <summary>
        /// Standard English matching. Depends on the intent's language.
        /// </summary>
        /// <remarks>
        /// For example, in English, spaces will be used as grouping but not part of exact matches.
        /// In Chinese on the other hand, spaces are irrelevant and not ignored. Oh, and everything is one long sentence.
        /// </remarks>
        Match,
        /// <summary>
        /// This will conform anything that doesn't fit the pattern as it; the wildcard input value.
        /// </summary>
        Wildcard,
        /// <summary>
        /// The same as a wildcard, but it needs to be part of a defined dictionary.
        /// </summary>
        DictionaryWildcard,
        /// <summary>
        /// This same as a wildcard, but must fit some specific format.
        /// </summary>
        SpecialWildcard
    }
}
