using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using TypedReader.Parsing;
using TypedReader.Tokenization;

namespace TypedReader
{
    /// <summary>
    /// A wrapper around <see cref="TextReader"/> which allows for reading typed tokens.
    /// </summary>
    public class Reader : IDisposable
    {
        private static readonly Dictionary<Type, object> Parsers = new Dictionary<Type, object>();

        private bool _disposed = false;
        private readonly Tokenizer _tokenizer;


        /// <summary>
        /// Creates an instance of <see cref="TextReader"/>.
        /// </summary>
        /// <param name="textReader">A <see cref="TextReader"/> instance from which data will be read.</param>
        /// <param name="options">Options for controlling the tokenization of the text reader content.</param>
        public Reader(TextReader textReader, Options options = null)
        {
            _tokenizer = new Tokenizer(textReader, options ?? Options.Default);
        }

        ~Reader()
        {
            Dispose(false);
        }

        /// <summary>
        /// Releases all resources used by the <see cref="Reader"/>
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                _tokenizer.Dispose();
            }

            _disposed = true;
        }

        /// <summary>
        /// Parses the next token into the specified type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The desired type of the next element.</typeparam>
        /// <returns>Returns the token parsed as an instance of the specified type <typeparamref name="T"/>.</returns>
        public T Next<T>()
        {
            var token = _tokenizer.Next();

            if (Parsers.TryGetValue(typeof(T), out var value))
            {
                var parser = (ITokenParser<T>)value;
                return parser.Parse(token);
            }
            else
            {
                var converter = TypeDescriptor.GetConverter(typeof(T));
                return (T)converter.ConvertFromString(token);
            }
        }

        /// <summary>
        /// Registers a parser for a type into the Reader <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type being parsed.</typeparam>
        /// <param name="parser">An instance of ITokenParser wich can parse <typeparamref name="T"/>.</param>
        public static void RegisterParser<T>(ITokenParser<T> parser)
        {
            Parsers[typeof(T)] = parser;
        }

    }
}
