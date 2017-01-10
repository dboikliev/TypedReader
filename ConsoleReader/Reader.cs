using ConsoleReader.Parsing;
using ConsoleReader.Tokenization;
using System;
using System.Collections.Generic;

namespace ConsoleReader
{

    public static class Reader
    {
        /// <summary>
        /// Options for the tokenizer.
        /// </summary>
        public static TokenizerOptions TokenizerOptions => Tokenizer.Options;
        private static Dictionary<Type, object> Parsers { get; } =
            new Dictionary<Type, object>();
        private static Tokenizer Tokenizer { get; } = new Tokenizer();

        static Reader()
        {
            Parsers[typeof(string)] = new StringTokenParser();
            Parsers[typeof(byte)] = new ByteTokenParser();
            Parsers[typeof(sbyte)] = new SByteTokenParser();
            Parsers[typeof(short)] = new Int16TokenParser();
            Parsers[typeof(ushort)] = new UInt16TokenParser();
            Parsers[typeof(int)] = new Int32TokenParser();
            Parsers[typeof(uint)] = new UInt32TokenParser();
            Parsers[typeof(long)] = new Int64TokenParser();
            Parsers[typeof(ulong)] = new UInt64TokenParser();

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
        /// <typeparam name="T"></typeparam>
        /// <returns>Returns the token parsed as an instnace of the speicifed type <typeparamref name="T"/>.</returns>
        public static T Next<T>()
        {
            var token = Tokenizer.Next();
            var parsed = ((ITokenParser<T>)Parsers[typeof(T)]).Parse(token);
            return parsed;
        }
    }
}
