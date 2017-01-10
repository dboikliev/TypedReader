using System;

namespace ConsoleReader.Parsing
{
    sealed class StringTokenParser : TokenParser<String>
    {
        public string Parse(string token)
        {
            return token;
        }
    }
}
