using ConsoleReader.Tokenization;
using System;
using System.IO;
using Xunit;

namespace ConsoleReader.Tests
{
    public class TokenizerTests
    {
        [Fact]
        public void Tokenizer_ShouldIgnore_SpaceSaparator()
        {
            var reader = new StringReader("  test1   test2   ");
            var tokenizer = new Tokenizer();

            var options = new TokenizerOptions
            {
                Separators = new[] { ' ' }
            };

            var token1 = tokenizer.Next(reader, options);
            var token2 = tokenizer.Next(reader, options);

            Assert.Equal("test1", token1);
            Assert.Equal("test2", token2);
        }


        [Fact]
        public void Tokenizer_ShouldIgnore_SymbolSaparator()
        {
            var reader = new StringReader("|||test1 test2|||test3 test4||");
            var tokenizer = new Tokenizer();

            var options = new TokenizerOptions
            {
                Separators = new[] { '|' }
            };

            var token1 = tokenizer.Next(reader, options);
            var token2 = tokenizer.Next(reader, options);

            Assert.Equal("test1 test2", token1);
            Assert.Equal("test3 test4", token2);
        }

        [Fact]
        public void Tokenizer_ShouldIgnore_NewLineSymbols()
        {
            var reader = new StringReader("|||test1 test2|||" + Environment.NewLine + "||test3 test4");
            var tokenizer = new Tokenizer();

            var options = new TokenizerOptions
            {
                Separators = new[] { '|' }
            };

            var token1 = tokenizer.Next(reader, options);
            var token2 = tokenizer.Next(reader, options);

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
            var tokenizer = new Tokenizer();

            var options = new TokenizerOptions
            {
                Separators = new[] { '|' }
            };

            var token1 = tokenizer.Next(reader, options);
            var token2 = tokenizer.Next(reader, options);

            Assert.Equal("test1 test2", token1);
            Assert.Equal("test3 test4", token2);
        }
    }
}
