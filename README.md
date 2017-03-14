# ConsoleReader
A small library providing a streamlined interface for reading different types of inputs from the console.
Similar in functionality to C++'s std::cin and Java.util.Scanner.nextInt(), Java.util.Scanner.nextFloat(), etc.

## Examples

### 1. Reading from console:

#### Code:

```csharp
using System;
using static ConsoleReader.Reader;

class Program
{
    static void Main(string[] args)
    {
        var a = Next<byte>();
        var b = Next<int>();
        var text = Next<string>();
        Console.WriteLine($"a: { a }, b: { b }, text: { text }");
    }
}
```

####Console input:

```
    123    456789   SomeText
```

####Console output:

```
a: 123, b: 456789, text: SomeText
```

###2. Registering a custom parser:

####Code:

```csharp
using ConsoleReader.Parsing;
using System.IO;

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

```

####Console input:

```
C:\some text.txt|D:\bla bla bla.txt
```

####Console output:

```
file1: C:\some text.txt, file2: D:\bla bla bla.txt
```
