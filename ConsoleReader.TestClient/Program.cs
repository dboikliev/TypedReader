using System;

namespace ConsoleReader.TestClient
{
    class Program
    {
        static void Main()
        {
            var number = Console.In.Next<decimal>();
            var boolean = Console.In.Next<bool>();
            Console.WriteLine(number);
            Console.WriteLine(boolean);
        }
    }
}