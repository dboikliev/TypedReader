# ConsoleReader
A small library providing a streamlined interface for reading different types of inputs from the console.
Similar in functionality to C++'s std::cin and Java.util.Scanner.nextInt(), Java.util.Scanner.nextFloat(), etc.

## Installation

```powershell
PM> Install-Package ConsoleReader
```

## Examples

### 1. Reading from console:

#### Code:

```csharp
using System;

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
using ConsoleReader.Parsing;
using ConsoleReader.Tokenization;

class Program
{
    static void Main(string[] args)
    {
        Reader.RegisterParser(new FileInfoTokenParser());

        //The following calls are interchangeable
        var file1 = Reader.Next<FileInfo>(Console.In, new TokenizerOptions { Separator = '|' });
        var file2 = Console.In.Next<FileInfo>('|');
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

#### Console input:

```
C:\some text.txt|D:\bla bla bla.txt
```

#### Console output:

```
file1: C:\some text.txt, file2: D:\bla bla bla.txt
```
