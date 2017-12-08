# TypedReader
A small library providing a streamlined interface for reading different types of inputs from TextReader instnaces including Console.In. Similar in functionality to C++'s std::cin and Java.util.Scanner.nextInt(), Java.util.Scanner.nextFloat(), etc.

## Examples

### 1. Reading from console:

#### Code:

```csharp
using System;

class Program
{
    static void Main(string[] args)
    {
        var console = new Reader(Console.In);
        var a = console.Next<byte>();
        var b = console.Next<int>();
        var text = console.Next<string>();
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
using ConsoleReader.Parsing;
using ConsoleReader.Tokenization;

class Program
{
    static void Main(string[] args)
    {
        Reader.RegisterParser(new FileInfoTokenParser());

        var console = new Reader(Console.In);
        var options = new TokenizerOptions('|');
        var file1 = console.Next<FileInfo>(options);
        var file2 = console.Next<FileInfo>(options);
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
