using ConsoleReader.Parsing;
using ConsoleReader.Tokenization;
using System;
using System.Collections.Generic;

namespace ConsoleReader
{

    public static class Reader
    {
        private static Dictionary<Type, object> Parsers { get; } =
            new Dictionary<Type, object>();

        public static void RegisterParser<TType>(ITokenParser<TType> parser)
        {
            Parsers[typeof(TType)] = parser;
        }

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

        private static Tokenizer Tokenizer { get; } = new Tokenizer();
        public static TokenizerOptions TokenizerOptions => Tokenizer.Options;

        public static T Next<T>()
        {
            var token = Tokenizer.Next();
            var parsed = ((ITokenParser<T>)Parsers[typeof(T)]).Parse(token);
            return parsed;
        }
    }
}
