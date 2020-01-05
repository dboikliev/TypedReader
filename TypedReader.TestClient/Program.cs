using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using TypedReader.Extensions;
using TypedReader.Parsing;

namespace TypedReader.TestClient
{
    [InProcess]
    public class TypedReaderVsDefault
    {
        class Int32Parser : ITokenParser<int>
        {
            public int Parse(string token)
            {
                return int.Parse(token);
            }
        }

        [Params(1000, 10000)]
        public int N;

        private string input;

        [GlobalSetup]
        public void Setup()
        {
            input = string.Join(Environment.NewLine, Enumerable.Repeat("1234567890", N));
        }

        [Benchmark]
        public int StringReader()
        {
            var reader = new StringReader(input);
            int total = 0;
            unchecked
            {
                for (int i = 0; i < N; i++)
                {
                    total += int.Parse(reader.ReadLine());
                }
            }
            return total;
        }

        [Benchmark]
        public int TypedReader()
        {
            var reader = new StringReader(input);
            int total = 0;
            Reader.RegisterParser<int>(null);
            unchecked
            {
                var typedReader = reader.AsTyped();
                for (int i = 0; i < N; i++)
                {
                    total += typedReader.Next<int>();
                }
            }
            return total;
        }


        [Benchmark]
        public int TypedReaderWithRegisteredParser()
        {
            var reader = new StringReader(input);
            int total = 0;
            Reader.RegisterParser(new Int32Parser());
            unchecked
            {
                var typedReader = reader.AsTyped();
                for (int i = 0; i < N; i++)
                {
                    total += typedReader.Next<int>();
                }
            }
            return total;
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