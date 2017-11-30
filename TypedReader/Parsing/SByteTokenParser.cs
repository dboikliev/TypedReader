namespace TypedReader.Parsing
{
    internal sealed class SByteTokenParser : ITokenParser<sbyte>
    {
        public sbyte Parse(string token)
        {
            return sbyte.Parse(token);
        }
    }
}
