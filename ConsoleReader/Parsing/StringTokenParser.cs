using System;

namespace ConsoleReader.Parsing
{
    sealed class StringTokenParser : ITokenParser<String>
    {
        public string Parse(string token)
        {
            return token;
        }
    }
}
