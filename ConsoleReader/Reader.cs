using ConsoleReader.Parsing;
using ConsoleReader.Tokenization;
using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleReader
{

    internal static class Reader
    {
        private static readonly Tokenizer _tokenizer = new Tokenizer();
        private static readonly Dictionary<Type, object> _parsers = new Dictionary<Type, object>();

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
        internal static void RegisterParser<T>(ITokenParser<T> parser)
        {
            _parsers[typeof(T)] = parser;
        }

        /// <summary>
        /// Parses the next token into the specified type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>Returns the token parsed as an instnace of the speicifed type <typeparamref name="T"/>.</returns>
        internal static T Next<T>(TextReader reader, TokenizerOptions options)
        {
            var token = _tokenizer.Next(reader, options);
            var parsed = ((ITokenParser<T>)_parsers[typeof(T)]).Parse(token);
            return parsed;
        }
    }
}
