using System;
using System.Globalization;
using System.Text;

namespace ConsoleReader.Tokenization
{
    static class Tokenizer
    {
        public static TokenizerOptions Options { get; } = new TokenizerOptions();

        public static string Next()
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
                    var characterCategory = char.GetUnicodeCategory(character);
                    while (characterCategory != UnicodeCategory.OtherNotAssigned &&
                        Environment.NewLine.Length > 1 &&
                        Environment.NewLine.StartsWith(character.ToString()))
                    {
                        character = (char)Console.Read();
                        if (hasReachedToken)
                        {
                            isTokenizing = false;
                        }
                    }


                    isTokenizing &= characterCategory != UnicodeCategory.OtherNotAssigned;
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
