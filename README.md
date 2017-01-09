# ConsoleReader
A simple library providing seamless interface for reading different types of inputs from the console.

#Examples:

##Reading from console:

###Code:

```csharp
using static ConsoleReader.Reader;

namespace ConsoleReader.TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = Next<byte>();
            var b = Next<int>();
            var text = Next<string>();
            System.Console.WriteLine($"a: { a }, b: { b }, text: { text }");
        }
    }
}
```

###Console Input:
    123    456789   SomeText

###Console Output:
a: 123, b: 456789, text: SomeText

