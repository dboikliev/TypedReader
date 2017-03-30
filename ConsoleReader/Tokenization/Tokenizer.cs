using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleReader.Tokenization
{
    internal class Tokenizer
    {
        public string Next(TextReader reader, TokenizerOptions options)
        {
            var builder = new StringBuilder();
            var isTokenizing = true;
            var hasReachedToken = false;
            while (isTokenizing)
            {
                var character = (char)reader.Read();
                if (character >= 0)
                {
                    var characterCategory = char.GetUnicodeCategory(character);
                    while (characterCategory != UnicodeCategory.OtherNotAssigned &&
                           Environment.NewLine.Length > 1 &&
                           Environment.NewLine.StartsWith(character.ToString()))
                    {
                        character = (char) reader.Read();
                        if (hasReachedToken)
                        {
                            isTokenizing = false;
                        }
                    }


                    isTokenizing &= characterCategory != UnicodeCategory.OtherNotAssigned;
                    if (!options.IgnoreWhiteSpace && char.IsWhiteSpace(character) ||
                        options.Separators.Contains(character))
                    {
                        if (hasReachedToken)
                        {
                            isTokenizing = false;
                        }
                    }
                    else if (isTokenizing && !Environment.NewLine.Contains(character.ToString()))
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
    }
}
