using ConsoleReader.Tokenization;
using System.IO;

namespace ConsoleReader
{
    public static class TextReaderExtensions
    {
        /// <summary>
        /// Parses the next token into the specified type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The desired type of the next element.</typeparam>
        /// <param name="reader">The source.</param>
        /// <param name="ignoreWhiteSpace">A flag which indicates whether to ignore whitespace symbols.</param>
        /// <param name="separators">Symbols which separate elements in the sequence.</param>
        /// <returns></returns>
        public static T Next<T>(this TextReader reader, bool ignoreWhiteSpace = true, params char[] separators)
        {
            var options = new TokenizerOptions(ignoreWhiteSpace, separators);
            return Reader.Next<T>(reader, options);
        }

        /// <summary>
        /// Parses the next token into the specified type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The desired type of the next element.</typeparam>
        /// <param name="reader">The source.</param>
        /// <param name="ignoreWhiteSpace">A flag which indicates whether to ignore whitespace symbols.</param>
        /// <param name="separator">A symbol which separates elements in the sequence.</param>
        /// <returns></returns>
        public static T Next<T>(this TextReader reader, char separator = ' ', bool ignoreWhiteSpace = true)
        {
            var options = new TokenizerOptions(ignoreWhiteSpace, separator);
            return Reader.Next<T>(reader, options);
        }
    }
}
