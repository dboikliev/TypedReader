using System;

namespace ConsoleReader.TestClient
{
    class Program
    {
        static void Main()
        {
            var number = Console.In.Next<decimal>();
            var number2 = Console.In.Next<decimal>('|');
            var number3 = Console.In.Next<decimal>('|');
            Console.WriteLine(number);
            Console.WriteLine(number2);
            Console.WriteLine(number3);
        }
    }
}
