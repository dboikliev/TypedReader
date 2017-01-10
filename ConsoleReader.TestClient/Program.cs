using ConsoleReader.Parsing;
using System.IO;

namespace ConsoleReader.TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Reader.TokenizerOptions.Separator = '|';
            Reader.RegisterParser(new FileInfoTokenParser());

            var file1 = Reader.Next<FileInfo>();
            var file2 = Reader.Next<FileInfo>();
            System.Console.WriteLine($"file1: { file1 }, file2: { file2 }");
        }
    }

    class FileInfoTokenParser : ITokenParser<FileInfo>
    {
        public FileInfo Parse(string token)
        {
            return new FileInfo(token);
        }
    }
}
