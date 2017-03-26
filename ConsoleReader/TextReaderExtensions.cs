using ConsoleReader.Tokenization;
using System.IO;

namespace ConsoleReader
{
    public static class TextReaderExtensions
    {
        public static T Next<T>(this TextReader reader, TokenizerOptions options = null)
        {
            var typedReader = new Reader();
            if (options != null)
            {
                typedReader.TokenizerOptions = options;
            }
            return typedReader.Next<T>(reader);
        }
    }
}
