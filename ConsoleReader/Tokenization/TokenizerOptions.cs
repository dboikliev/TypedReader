namespace ConsoleReader.Tokenization
{
    public class TokenizerOptions
    {
        /// <summary>
        /// The character by which the user input will be split.
        /// </summary>
        public char[] Separators { get; } = { ' ' };

        /// <summary>
        /// Flag which indicates whether to ignore the whitespace symbols
        /// </summary>
        public bool IgnoreWhiteSpace { get; }

        public TokenizerOptions(params char[] separators) : this(true, separators)
        {
        }
        
        public TokenizerOptions(bool ignoreWhiteSpace, params char[] separators)
        {
            if (separators.Length > 0)
                Separators = separators;

            IgnoreWhiteSpace = ignoreWhiteSpace;
        }
    }
}
