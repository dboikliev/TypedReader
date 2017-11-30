﻿namespace TypedReader.Parsing
{
    internal sealed class FloatTokenParser : ITokenParser<float>
    {
        public float Parse(string token)
        {
            return float.Parse(token);
        }
    }
}