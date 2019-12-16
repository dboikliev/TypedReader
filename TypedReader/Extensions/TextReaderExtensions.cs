using System.IO;
using TypedReader.Tokenization;

namespace TypedReader.Extensions
{
    public static class TextReaderExtensions
    {
        public static Reader AsTyped(this TextReader textReader, Options options = null) => new Reader(textReader, options);
    }
}