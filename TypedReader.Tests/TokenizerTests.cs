using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using TypedReader.Tokenization;
using Xunit;

namespace TypedReader.Tests
{
    public class TokenizerTests
    {
        [Fact]
        public void Tokenizer_ShouldIgnore_SpaceSaparator()
        {
            var reader = new StringReader("  1234567890   test2   ");

            var options = new Options(' ');

            var tokenizer = new Tokenizer(reader, options);
            var token1 = tokenizer.Next();
            var token2 = tokenizer.Next();

            Assert.Equal("1234567890", token1);
            Assert.Equal("test2", token2);
        }
        [Fact]
        public void Tokenizer_ShouldTokenize_LongSequence()
        {
            int count = Tokenizer.BufferSize + 15;
            var reader = new StringReader(string.Join(' ', Enumerable.Repeat("1234567890", count)));

            var options = new Options(' ');

            var tokenizer = new Tokenizer(reader, options);
            for (int i = 0; i < count; i++)
            {
                Debug.WriteLine(i);
                Assert.Equal("1234567890", tokenizer.Next());
            }
        }


        [Fact]
        public void Tokenizer_ShouldIgnore_SymbolSaparator()
        {
            var reader = new StringReader("|||test1 test2|||test3 test4||");

            var options = new Options('|');

            var tokenizer = new Tokenizer(reader, options);
            var token1 = tokenizer.Next();
            var token2 = tokenizer.Next();

            Assert.Equal("test1 test2", token1);
            Assert.Equal("test3 test4", token2);
        }

        [Fact]
        public void Tokenizer_ShouldIgnore_NewLineSymbols()
        {
            var reader = new StringReader("|||test1 test2|||\r\r\n\r\n\n\ntest3 test4|\r\r\n\r\n\n\n|test 5");

            var options = new Options('|');

            var tokenizer = new Tokenizer(reader, options);

            Assert.Equal("test1 test2", tokenizer.Next());
            Assert.Equal("test3 test4", tokenizer.Next());
            Assert.Equal("test 5", tokenizer.Next());
        }

    }
}
