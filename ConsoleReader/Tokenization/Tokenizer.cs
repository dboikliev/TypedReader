using System;
using System.Text;

namespace ConsoleReader.Tokenization
{
    class Tokenizer
    {
        public TokenizerOptions Options { get; } = new TokenizerOptions();

        public string Next()
        {
            var builder = new StringBuilder();
            var isTokenizing = true;
            var hasReachedToken = false;
            while (isTokenizing)
            {
                var character = (char)Console.Read();
                if (character < 0)
                {
                    isTokenizing = false;
                }
                else
                {
                    while (Environment.NewLine.Length > 1 &&
                        Environment.NewLine.StartsWith(character.ToString()))
                    {
                        character = (char)Console.Read();
                        isTokenizing = false;
                    }

                    if (character == Options.Separator)
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
            }

            var token = builder.ToString();
            return token;
        }
    }
}
