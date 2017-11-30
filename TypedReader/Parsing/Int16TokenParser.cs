﻿namespace TypedReader.Parsing
{
    internal sealed class Int16TokenParser : ITokenParser<short>
    {
        public short Parse(string token)
        {
            return short.Parse(token);
        }
    }
}