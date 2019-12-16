using System;
using System.IO;
using Xunit;

namespace TypedReader.Tests
{
    public class ReaderTests
    {
        [Fact]
        public void Reader_ShouldRead_Int()
        {
            var reader = new StringReader("  123   456   ");
            Console.SetIn(reader);

            var typedReader = new Reader(Console.In);
            int first = typedReader.Next<int>();
            int second = typedReader.Next<int>();

            Assert.Equal(123, first);
            Assert.Equal(456, second);
        }

        [Fact]
        public void Reader_ShouldRead_String()
        {
            var reader = new StringReader("  abc   def   ");
            Console.SetIn(reader);

            var typedReader = new Reader(Console.In);
            string first = typedReader.Next<string>();
            string second = typedReader.Next<string>();

            Assert.Equal("abc", first);
            Assert.Equal("def", second);
        }

        [Fact]
        public void Reader_ShouldRead_MixedTypes()
        {
            var reader = new StringReader("  abc   123   ");
            Console.SetIn(reader);

            var typedReader = new Reader(Console.In);
            string first = typedReader.Next<string>();
            int second = typedReader.Next<int>();

            Assert.Equal("abc", first);
            Assert.Equal(123, second);
        }
    }
}
