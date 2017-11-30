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

            var console = new Reader(Console.In);
            int first = console.Next<int>();
            int second = console.Next<int>();

            Assert.Equal(123, first);
            Assert.Equal(456, second);
        }

        [Fact]
        public void Reader_ShouldRead_String()
        {
            var reader = new StringReader("  abc   def   ");
            Console.SetIn(reader);

            var console = new Reader(Console.In);
            string first = console.Next<string>();
            string second = console.Next<string>();

            Assert.Equal("abc", first);
            Assert.Equal("def", second);
        }

        [Fact]
        public void Reader_ShouldRead_MixedTypes()
        {
            var reader = new StringReader("  abc   123   ");
            Console.SetIn(reader);

            var console = new Reader(Console.In);
            string first = console.Next<string>();
            int second = console.Next<int>();

            Assert.Equal("abc", first);
            Assert.Equal(123, second);
        }
    }
}
