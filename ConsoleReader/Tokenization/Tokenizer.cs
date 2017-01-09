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
                    if (character == Options.Separator)
                    {
                        if (hasReachedToken)
                        {
                            isTokenizing = false;
                        }
                    }
                    else
                    {
                        hasReachedToken = true;
                        builder.Append(character);
                    }


                    while (Environment.NewLine.Length > 1 &&
                        Environment.NewLine.StartsWith(character.ToString()))
                    {
                        character = (char)Console.Read();
                        isTokenizing = false;
                    }
                }
            }

            var token = builder.ToString();
            return token;
        }
    }
}
