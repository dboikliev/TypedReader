using ConsoleReader.Parsing;
using ConsoleReader.Tokenization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ConsoleReader
{
    public static class Reader
    {
        private static readonly Tokenizer Tokenizer = new Tokenizer();
        private static readonly Dictionary<Type, object> Parsers = new Dictionary<Type, object>();

        static Reader()
        {
            var assemblyTypes = Assembly.GetExecutingAssembly()
                .GetTypes();

            foreach (var type in assemblyTypes)
            {
                var parserInterface = type.GetInterfaces()
                    .FirstOrDefault(i => i.IsConstructedGenericType && i.GetGenericTypeDefinition() == typeof(ITokenParser<>));

                if (parserInterface != null)
                {
                    var parsingType = parserInterface.GenericTypeArguments.First();

                    Parsers[parsingType] = Activator.CreateInstance(type);
                }
            }
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
