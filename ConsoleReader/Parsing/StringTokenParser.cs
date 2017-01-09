using System;

namespace ConsoleReader.Parsing
{
    sealed class StringTokenParser : TokenParser<String>
    {
        public override string Parse(string token)
        {
            return token;
        }
    }
}
