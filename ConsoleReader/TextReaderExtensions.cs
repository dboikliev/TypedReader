using System.IO;

namespace ConsoleReader
{
    static class TextReaderExtensions
    {
        public static T Next<T>(this TextReader reader)
        {
            var typedReader = new Reader();
            return typedReader.Next<T>(reader);
        }
    }
}
