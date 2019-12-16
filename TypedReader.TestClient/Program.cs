using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.IO;
using System.Linq;
using TypedReader.Extensions;

namespace TypedReader.TestClient
{
    [RPlotExporter, RankColumn, InProcess]
    public class TypedReaderVsDefault
    {

        [Params(1, 10, 100, 1000, 10000, 100000)]
        public int N;

        private string input;

        [GlobalSetup]
        public void Setup()
        {
            input = string.Join(Environment.NewLine, Enumerable.Repeat("1234567890", N));
        }

        [Benchmark]
        public void WithoutTypedReader()
        {
            Console.SetIn(new StringReader(input));
            int total = 0;
            unchecked
            {
                for (int i = 0; i < N; i++)
                {
                    total += int.Parse(Console.ReadLine());
                }
            }
        }

        [Benchmark]
        public void WithTypedReader()
        {
            Console.SetIn(new StringReader(input));
            int total = 0;
            unchecked
            {
                var reader = Console.In.AsTyped();
                for (int i = 0; i < N; i++)
                {
                    total += reader.Next<int>();
                }
            }
        }
    }

    class Program
    {
        static void Main()
        {
            BenchmarkRunner.Run<TypedReaderVsDefault>();
        }
    }
}