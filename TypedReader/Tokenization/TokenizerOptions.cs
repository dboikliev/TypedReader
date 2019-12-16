using System.Collections.ObjectModel;

namespace TypedReader.Tokenization
{
    /// <summary>
    /// Options for controlling the tokenization of the text reader content.
    /// </summary>
    public class Options
    {
        public static readonly Options Default = new Options();

        /// <summary>
        /// The character by which the user input will be split.
        /// </summary>
        public ReadOnlyCollection<char> Separators { get; }

        /// <summary>
        /// Flag which indicates whether to ignore the whitespace symbols
        /// </summary>
        public bool IgnoreWhiteSpace { get; }

        public Options(params char[] separators) : this(true, separators)
        {
        }

        public Options(bool ignoreWhiteSpace, params char[] separators)
        {
            Separators = new ReadOnlyCollection<char>(separators.Length == 0 ? new[] { ' ' } : separators);
            IgnoreWhiteSpace = ignoreWhiteSpace;
        }
    }
}
