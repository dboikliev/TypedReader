using ConsoleReader.Parsing;
using ConsoleReader.Tokenization;
using System;
using System.Collections.Generic;

namespace ConsoleReader
{

    public static class Reader
    {
        private static Dictionary<Type, Lazy<object>> Parsers { get; } =
            new Dictionary<Type, Lazy<object>>();

        public static void RegisterParser<T>() where T : TokenParser<T>, new()
        {
            Parsers[typeof(T)] = new Lazy<object>(() => new T());
        }

        static Reader()
        {
            Parsers[typeof(string)] = new Lazy<object>(() => new StringTokenParser());
            Parsers[typeof(byte)] = new Lazy<object>(() => new ByteTokenParser());
            Parsers[typeof(sbyte)] = new Lazy<object>(() => new SByteTokenParser());
            Parsers[typeof(short)] = new Lazy<object>(() => new Int16TokenParser());
            Parsers[typeof(ushort)] = new Lazy<object>(() => new UInt16TokenParser());
            Parsers[typeof(int)] = new Lazy<object>(() => new Int32TokenParser());
            Parsers[typeof(uint)] = new Lazy<object>(() => new UInt32TokenParser());
            Parsers[typeof(long)] = new Lazy<object>(() => new Int64TokenParser());
            Parsers[typeof(ulong)] = new Lazy<object>(() => new UInt64TokenParser());

        }

        private static Tokenizer Tokenizer { get; } = new Tokenizer();
        public static TokenizerOptions TokenizerOptions => Tokenizer.Options;

        public static T Next<T>()
        {
            var token = Tokenizer.Next();
            var parsed = ((TokenParser<T>)Parsers[typeof(T)].Value).Parse(token);
            return parsed;
        }
    }
}
