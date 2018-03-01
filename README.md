# TypedReader
A small library providing a streamlined interface for reading different types of inputs from TextReader instances including Console.In. Similar in functionality to C++'s std::cin and Java.util.Scanner.nextInt(), Java.util.Scanner.nextFloat(), etc.

## Examples

### 1. Reading from console:

#### Code:

```csharp
using System;
using TypedReader.Extensions;

class Program
{
    static void Main(string[] args)
    {
        var a = Console.In.Next<byte>();
        var b = Console.In.Next<int>();
        var text = Console.In.Next<string>();
        Console.WriteLine($"a: { a }, b: { b }, text: { text }");
    }
}
```

#### Console input:

```
    123    456789   SomeText
```

#### Console output:

```
a: 123, b: 456789, text: SomeText
```

### 2. Registering a custom parser:

#### Code:

```csharp
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

```

#### Console input:

```
C:\some text.txt|D:\bla bla bla.txt
```

#### Console output:

```
file1: C:\some text.txt, file2: D:\bla bla bla.txt
```
