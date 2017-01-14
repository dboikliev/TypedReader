using System;

namespace ConsoleReader.TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = Reader.Next<decimal>();
            Console.WriteLine(number);
        }
    }
}
