using System;
using System.Globalization;
using System.IO;
using System.Text;

namespace TypedReader.Tokenization
{
    internal sealed class Tokenizer : IDisposable
    {
        internal const short BufferSize = 4096;
        private readonly TextReader _reader;
        private readonly Options _options;
        private readonly char[] _block = new char[BufferSize];
        private int? _remainingChars;
        private int? _startIndex;

        public Tokenizer(TextReader reader, Options options)
        {
            _reader = reader;
            _options = options;
        }


        public string Next()
        {
            var isTokenizing = true;
            var hasReachedToken = false;

            int current = _startIndex.GetValueOrDefault(0);
            if (_remainingChars.GetValueOrDefault(-1) <= 0)
            {
                _remainingChars = _reader.ReadBlock(_block);
                current = 0;
                _startIndex = 0;
            }

            var builder = new StringBuilder(64);
            while (isTokenizing)
            {
                if (_remainingChars <= 0)
                {
                    _remainingChars = _reader.ReadBlock(_block);
                    current = 0;
                }

                if (_remainingChars > 0)
                {
                    ref var character = ref _block[current++];
                    _remainingChars--;


                    isTokenizing &= char.GetUnicodeCategory(character)
                        != UnicodeCategory.OtherNotAssigned;

                    var isTerminatingCharacter = character == '\0'
                        || !_options.IgnoreWhiteSpace && char.IsWhiteSpace(character) // is separating whitespace
                        || _options.Separators.Contains(character)
                        || character == '\r' || character == '\n'; // is new line

                    if (isTerminatingCharacter)
                    {
                        if (hasReachedToken)
                        {
                            isTokenizing = false;
                        }
                    }
                    else if (isTokenizing)
                    {
                        hasReachedToken = true;
                        builder.Append(character);
                    }
                }
                else
                {
                    isTokenizing = false;
                }
            }

            _startIndex = current;

            return builder.ToString();
        }

        public void Dispose()
        {
            _reader.Dispose();
        }
    }
}
