namespace ConsoleReader.Tokenization
{
    public class TokenizerOptions
    {
        /// <summary>
        /// The character by which the user input will be split.
        /// </summary>
        public char Separator { get; set; } = ' ';

        /// <summary>
        /// Flag which indicates whether to ignore the whitespace symbols
        /// </summary>
        public bool IgnoreWhiteSpace { get; set; } = true;
    }
}
