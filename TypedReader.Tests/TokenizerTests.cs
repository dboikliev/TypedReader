using System;
using System.IO;
using TypedReader.Tokenization;
using Xunit;

namespace TypedReader.Tests
{
    public class TokenizerTests
    {
        [Fact]
        public void Tokenizer_ShouldIgnore_SpaceSaparator()
        {
            var reader = new StringReader("  test1   test2   ");

            var options = new TokenizerOptions(' ');

            var token1 = Tokenizer.Next(reader, options);
            var token2 = Tokenizer.Next(reader, options);

            Assert.Equal("test1", token1);
            Assert.Equal("test2", token2);
        }


        [Fact]
        public void Tokenizer_ShouldIgnore_SymbolSaparator()
        {
            var reader = new StringReader("|||test1 test2|||test3 test4||");

            var options = new TokenizerOptions('|');

            var token1 = Tokenizer.Next(reader, options);
            var token2 = Tokenizer.Next(reader, options);

            Assert.Equal("test1 test2", token1);
            Assert.Equal("test3 test4", token2);
        }

        [Fact]
        public void Tokenizer_ShouldIgnore_NewLineSymbols()
        {
            var reader = new StringReader("|||test1 test2|||" + Environment.NewLine + "||test3 test4");

            var options = new TokenizerOptions('|');

            var token1 = Tokenizer.Next(reader, options);
            var token2 = Tokenizer.Next(reader, options);

            Assert.Equal("test1 test2", token1);
            Assert.Equal("test3 test4", token2);
        }

        [Fact]
        public void Tokenizer_ShouldIgnore_MultipleNewLineSymbols()
        {
            var reader = new StringReader("|||test1 test2|||" +
                                           Environment.NewLine +
                                           Environment.NewLine +
                                          "||test3 test4" +
                                           Environment.NewLine +
                                           Environment.NewLine +
                                          "  || || ");

            var options = new TokenizerOptions('|');

            var token1 = Tokenizer.Next(reader, options);
            var token2 = Tokenizer.Next(reader, options);

            Assert.Equal("test1 test2", token1);
            Assert.Equal("test3 test4", token2);
        }
    }
}
