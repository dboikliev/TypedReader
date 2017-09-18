using System;
using System.IO;
using Xunit;

namespace ConsoleReader.Tests
{
    public class ReaderTests
    {
        [Fact]
        public void Reader_ShouldRead_Int()
        {
            var reader = new StringReader("  123   456   ");
            Console.SetIn(reader);
            
            int first = Console.In.Next<int>();
            int second = Console.In.Next<int>();

            Assert.Equal(123, first);
            Assert.Equal(456, second);
        }

        [Fact]
        public void Reader_ShouldRead_String()
        {
            var reader = new StringReader("  abc   def   ");
            Console.SetIn(reader);

            string first = Console.In.Next<string>();
            string second = Console.In.Next<string>();

            Assert.Equal("abc", first);
            Assert.Equal("def", second);
        }

        [Fact]
        public void Reader_ShouldRead_MixedTypes()
        {
            var reader = new StringReader("  abc   123   ");
            Console.SetIn(reader);

            string first = Console.In.Next<string>();
            int second = Console.In.Next<int>();

            Assert.Equal("abc", first);
            Assert.Equal(123, second);
        }
    }
}
