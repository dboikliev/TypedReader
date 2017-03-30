using ConsoleReader.Parsing;
using ConsoleReader.Tokenization;
using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleReader
{
    public static class Reader
    {
        private static readonly Tokenizer Tokenizer = new Tokenizer();
        private static readonly Dictionary<Type, object> Parsers = new Dictionary<Type, object>();

        static Reader()
        {
            Parsers[typeof(string)] = new StringTokenParser();
            Parsers[typeof(sbyte)] = new SByteTokenParser();
            Parsers[typeof(byte)] = new ByteTokenParser();
            Parsers[typeof(short)] = new Int16TokenParser();
            Parsers[typeof(ushort)] = new UInt16TokenParser();
            Parsers[typeof(int)] = new Int32TokenParser();
            Parsers[typeof(uint)] = new UInt32TokenParser();
            Parsers[typeof(long)] = new Int64TokenParser();
            Parsers[typeof(ulong)] = new UInt64TokenParser();
            Parsers[typeof(float)] = new FloatTokenParser();
            Parsers[typeof(double)] = new DoubleTokenParser();
            Parsers[typeof(decimal)] = new DecimalTokenParser();
        }

        /// <summary>
        /// Registers a parser for a type into the Reader <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type being parsed</typeparam>
        /// <param name="parser">An instance of ITokenParser wich can parse <typeparamref name="T"/>.</param>
        public static void RegisterParser<T>(ITokenParser<T> parser)
        {
            Parsers[typeof(T)] = parser;
        }

        /// <summary>
        /// Parses the next token into the specified type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The desired type of the next element.</typeparam>
        /// <returns>Returns the token parsed as an instance of the specified type <typeparamref name="T"/>.</returns>
        public static T Next<T>(TextReader reader, TokenizerOptions options)
        {
            var token = Tokenizer.Next(reader, options);
            var parsed = ((ITokenParser<T>)Parsers[typeof(T)]).Parse(token);
            return parsed;
        }
    }
}
