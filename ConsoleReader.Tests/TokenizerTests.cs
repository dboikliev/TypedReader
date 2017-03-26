using ConsoleReader.Tokenization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ConsoleReader.Tests
{
    [TestClass]
    public class TokenizerTests
    {
        [TestMethod, Timeout(80)]
        public void Tokenizer_ShouldIgnore_SpaceSaparator()
        {
            var reader = new StringReader("  test1   test2   ");
            var tokenizer = new Tokenizer();
            tokenizer.Options.Separator = ' ';

            var token1 = tokenizer.Next(reader);
            var token2 = tokenizer.Next(reader);

            Assert.AreEqual("test1", token1);
            Assert.AreEqual("test2", token2);
        }


        [TestMethod, Timeout(80)]
        public void Tokenizer_ShouldIgnore_SymbolSaparator()
        {
            var reader = new StringReader("|||test1 test2|||test3 test4||");
            var tokenizer = new Tokenizer();
            tokenizer.Options.Separator = '|';

            var token1 = tokenizer.Next(reader);
            var token2 = tokenizer.Next(reader);

            Assert.AreEqual("test1 test2", token1);
            Assert.AreEqual("test3 test4", token2);
        }

        [TestMethod, Timeout(80)]
        public void Tokenizer_ShouldIgnore_NewLineSymbols()
        {
            var reader = new StringReader("|||test1 test2|||" + Environment.NewLine + "||test3 test4");
            var tokenizer = new Tokenizer();
            tokenizer.Options.Separator = '|';

            var token1 = tokenizer.Next(reader);
            var token2 = tokenizer.Next(reader);

            Assert.AreEqual("test1 test2", token1);
            Assert.AreEqual("test3 test4", token2);
        }

        [TestMethod]
        public void Tokenizer_ShouldIgnore_MultipleNewLineSymbols()
        {
            var reader = new StringReader("|||test1 test2|||" +
                                           Environment.NewLine +
                                           Environment.NewLine +
                                          "||test3 test4" +
                                           Environment.NewLine +
                                           Environment.NewLine +
                                          "  || || ");
            var tokenizer = new Tokenizer();
            tokenizer.Options.Separator = '|';

            var token1 = tokenizer.Next(reader);
            var token2 = tokenizer.Next(reader);

            Assert.AreEqual("test1 test2", token1);
            Assert.AreEqual("test3 test4", token2);
        }
    }
}
