using System;
using System.Collections.Generic;
using TypedReader.Extensions;

namespace TypedReader.TestClient
{
    class Program
    {
        static void Main()
        {
            IEnumerable<int> input = Console.In.Next<int>(5);
            IEnumerable<string> input2 = Console.In.Next<string>(3);

            Console.WriteLine(string.Join(",", input));
            Console.WriteLine(string.Join(",", input2));
        }
    }
}