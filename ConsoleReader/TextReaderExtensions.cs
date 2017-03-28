using ConsoleReader.Tokenization;
using System.IO;

namespace ConsoleReader
{
    public static class TextReaderExtensions
    {
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
