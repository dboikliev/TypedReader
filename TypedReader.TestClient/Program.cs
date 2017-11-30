
using System;

namespace TypedReader.TestClient
{
    class Program
    {
        static void Main()
        {
            var reader = new Reader(Console.In);

            reader.Next<int>();
        }
    }
}