using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace TypedReader.Tokenization
{
    internal static class Tokenizer
    {
        public static string Next(TextReader reader, TokenizerOptions options)
        {
            var builder = new StringBuilder();
            var isTokenizing = true;
            var hasReachedToken = false;
            while (isTokenizing)
            {
                var character = (char)reader.Read();
                if (character >= 0)
                {
                    while (ShouldIgnore(character))
                    {
                        character = (char)reader.Read();

                        if (hasReachedToken)
                            isTokenizing = false;
                    }

                    isTokenizing &= char.GetUnicodeCategory(character)
                        != UnicodeCategory.OtherNotAssigned;

                    if (IsTerminatingCharacter(options, character))
                    {
                        if (hasReachedToken)
                            isTokenizing = false;
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

            var token = builder.ToString();
            return token;
        }

        private static bool ShouldIgnore(char character)
        {
            return char.GetUnicodeCategory(character) != UnicodeCategory.OtherNotAssigned &&
                                       Environment.NewLine.Length > 1 &&
                                       Environment.NewLine.StartsWith(character.ToString());
        }

        private static bool IsTerminatingCharacter(TokenizerOptions options, char character)
        {
            var isSeparatingWhiteSpace = !options.IgnoreWhiteSpace && char.IsWhiteSpace(character);
            var isSeparatorCharacter = options.Separators.Contains(character);
            var isNewLineCharacter = Environment.NewLine.Contains(character.ToString());

            return isSeparatingWhiteSpace || isSeparatorCharacter || isNewLineCharacter;
        }
    }
}
