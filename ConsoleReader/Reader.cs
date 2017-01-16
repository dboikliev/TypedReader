using ConsoleReader.Parsing;
using ConsoleReader.Tokenization;
using System;
using System.Collections.Generic;

namespace ConsoleReader
{

    public static class Reader
    {
        private static readonly Tokenizer _tokenizer = new Tokenizer();
        private static readonly Dictionary<Type, object> _parsers = new Dictionary<Type, object>();

        /// <summary>
        /// Options for the tokenizer.
        /// </summary>
        public static TokenizerOptions TokenizerOptions => _tokenizer.Options;

        static Reader()
        {
            _parsers[typeof(string)] = new StringTokenParser();
            _parsers[typeof(sbyte)] = new SByteTokenParser();
            _parsers[typeof(byte)] = new ByteTokenParser();
            _parsers[typeof(short)] = new Int16TokenParser();
            _parsers[typeof(ushort)] = new UInt16TokenParser();
            _parsers[typeof(int)] = new Int32TokenParser();
            _parsers[typeof(uint)] = new UInt32TokenParser();
            _parsers[typeof(long)] = new Int64TokenParser();
            _parsers[typeof(ulong)] = new UInt64TokenParser();
            _parsers[typeof(float)] = new FloatTokenParser();
            _parsers[typeof(double)] = new DoubleTokenParser();
            _parsers[typeof(decimal)] = new DecimalTokenParser();
        }

        /// <summary>
        /// Registers a parser for a type into the Reader <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type being parsed</typeparam>
        /// <param name="parser">An instance of ITokenParser wich can parse <typeparamref name="T"/>.</param>
        public static void RegisterParser<T>(ITokenParser<T> parser)
        {
            _parsers[typeof(T)] = parser;
        }

        /// <summary>
        /// Parses the next token into the specified type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>Returns the token parsed as an instnace of the speicifed type <typeparamref name="T"/>.</returns>
        public static T Next<T>()
        {
            var token = _tokenizer.Next();
            var parsed = ((ITokenParser<T>)_parsers[typeof(T)]).Parse(token);
            return parsed;
        }
    }
}
