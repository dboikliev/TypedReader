using ConsoleReader.Parsing;
using System;
using System.IO;

namespace ConsoleReader.TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Reader.RegisterParser(new FileInfoTokenParser());
            Reader.TokenizerOptions.Separator = '|';
            var file = Reader.Next<FileInfo>();
            var text = Reader.Next<string>();
            Console.WriteLine($"file: { file }, string: { text }");
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
