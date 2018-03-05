using System.Collections.Generic;
using System.IO;
using TypedReader.Tokenization;

namespace TypedReader.Extensions
{
    public static class TextReaderExtensions
    {
        /// <summary>
        /// Parses the next token into the specified type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The desired type of the next element.</typeparam>
        /// <param name="textReader">A <code>TextReader</code> instance from whcih data will be read.</param>
        /// <param name="options">Options which control the way tokenization is performed.</param>
        /// <returns>Returns the token parsed as an instance of the specified type <typeparamref name="T"/>.</returns>
        public static T Next<T>(this TextReader textReader, TokenizerOptions options = null) =>
            Reader.Next<T>(textReader, options);

        public static IEnumerable<T> Next<T>(this TextReader textReader, int count, TokenizerOptions options = null)
        {
            for (int i = 0; i < count; i++)
            {
                yield return Reader.Next<T>(textReader, options);
            }
        }
    }
}