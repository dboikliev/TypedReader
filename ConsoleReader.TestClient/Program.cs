
using System;

namespace ConsoleReader.TestClient
{
    class Program
    {
        static void Main()
        {
            var a = Console.In.Next<int>();
            var b = Console.In.Next<double>();
            var c = Console.In.Next<bool>();
            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);
        }
    }
}