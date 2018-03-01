using System;
using System.IO;
using TypedReader;
using TypedReader.Extensions;
using TypedReader.Parsing;
using TypedReader.Tokenization;

class Program
{
    static void Main(string[] args)
    {
        Reader.RegisterParser(new FileInfoTokenParser());

        var options = new TokenizerOptions('|');
        var file1 = Console.In.Next<FileInfo>(options);
        var file2 = Console.In.Next<FileInfo>(options);
        Console.WriteLine($"file1: { file1 }, file2: { file2 }");
    }
}

class FileInfoTokenParser : ITokenParser<FileInfo>
{
    public FileInfo Parse(string token) => new FileInfo(token);
}