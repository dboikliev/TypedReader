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
        /// <param name="separator">A symbol which separates elements in the sequence.</param>
        /// <param name="ignoreWhiteSpace">A flag which indicates whether to ignore whitespace symbols.</param>
        /// <returns></returns>
        public static T Next<T>(this TextReader reader, char separator = ' ', bool ignoreWhiteSpace = true)
        {
            var options = new TokenizerOptions
            {
                Separator = separator,
                IgnoreWhiteSpace = ignoreWhiteSpace
            };
            return Reader.Next<T>(reader, options);
        }
    }
}
