using ConsoleReader;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ConsoleConsoleReader.Tests
{
    [TestClass]
    public class ReaderTests
    {
        [TestMethod, Timeout(80)]
        public void Reader_ShouldRead_Int()
        {
            var reader = new StringReader("  123   456   ");
            Console.SetIn(reader);
            
            int first = ConsoleReader.ConsoleReader.Next<int>();
            int second = ConsoleReader.ConsoleReader.Next<int>();

            Assert.AreEqual(123, first);
            Assert.AreEqual(456, second);
        }

        [TestMethod]
        public void Reader_ShouldRead_String()
        {
            var reader = new StringReader("  abc   def   ");
            Console.SetIn(reader);

            string first = ConsoleReader.ConsoleReader.Next<string>();
            string second = ConsoleReader.ConsoleReader.Next<string>();

            Assert.AreEqual("abc", first);
            Assert.AreEqual("def", second);
        }

        [TestMethod]
        public void Reader_ShouldRead_MixedTypes()
        {
            var reader = new StringReader("  abc   123   ");
            Console.SetIn(reader);

            string first = ConsoleReader.ConsoleReader.Next<string>();
            int second = ConsoleReader.ConsoleReader.Next<int>();

            Assert.AreEqual("abc", first);
            Assert.AreEqual(123, second);
        }
    }
}
