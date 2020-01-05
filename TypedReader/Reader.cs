using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
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
        private static readonly Dictionary<Type, TypeConverter> TypeConverters = new Dictionary<Type, TypeConverter>();

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
        /// Parses the next token into the specified type <typeparamref name="T"/> using the specified culture information.
        /// </summary>
        /// <typeparam name="T">The desired type of the next element.</typeparam>
        /// <param name="culture">The culture info used for parsing. Current culture is null is passed.</param>
        /// <returns>Returns the token parsed as an instance of the specified type <typeparamref name="T"/>.</returns>
        public T Next<T>(CultureInfo culture = null)
        {
            culture ??= CultureInfo.CurrentCulture;
            var token = _tokenizer.Next();

            if (Parsers.TryGetValue(typeof(T), out var value) && value != null)
            {
                var parser = (ITokenParser<T>)value;
                return parser.Parse(token);
            }
            else
            {
                return (T)GetOrCreateTypeConverter<T>().ConvertFromString(null, culture, token);
            }
        }

        private TypeConverter GetOrCreateTypeConverter<T>()
        {
            if (TypeConverters.TryGetValue(typeof(T), out var converter))
            {
                return converter;
            }
            var newConverter = TypeDescriptor.GetConverter(typeof(T));
            TypeConverters[typeof(T)] = newConverter;
            return newConverter;
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
