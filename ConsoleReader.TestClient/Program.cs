
using System;

namespace ConsoleReader.TestClient
{
    class Program
    {
        static void Main()
        {
            var a = Console.In.Next<int>();
            var b = Console.In.Next<float>();
            var c = Console.In.Next<bool>();
        }
    }
}