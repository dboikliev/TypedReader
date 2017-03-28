using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ConsoleReader.Tests
{
    [TestClass]
    public class ReaderTests
    {
        [TestMethod, Timeout(80)]
        public void Reader_ShouldRead_Int()
        {
            var reader = new StringReader("  123   456   ");
            Console.SetIn(reader);
            
            int first = Console.In.Next<int>();
            int second = Console.In.Next<int>();

            Assert.AreEqual(123, first);
            Assert.AreEqual(456, second);
        }

        [TestMethod, Timeout(80)]
        public void Reader_ShouldRead_String()
        {
            var reader = new StringReader("  abc   def   ");
            Console.SetIn(reader);

            string first = Console.In.Next<string>();
            string second = Console.In.Next<string>();

            Assert.AreEqual("abc", first);
            Assert.AreEqual("def", second);
        }

        [TestMethod, Timeout(80)]
        public void Reader_ShouldRead_MixedTypes()
        {
            var reader = new StringReader("  abc   123   ");
            Console.SetIn(reader);

            string first = Console.In.Next<string>();
            int second = Console.In.Next<int>();

            Assert.AreEqual("abc", first);
            Assert.AreEqual(123, second);
        }
    }
}
