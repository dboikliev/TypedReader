using System;

namespace ConsoleReader.TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = ConsoleReader.Next<decimal>();
            Console.WriteLine(number);
        }
    }
}
