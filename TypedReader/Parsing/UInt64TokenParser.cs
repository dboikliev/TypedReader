namespace TypedReader.Parsing
{
    internal sealed class UInt64TokenParser : ITokenParser<ulong>
    {
        public ulong Parse(string token)
        {
            return ulong.Parse(token);
        }
    }
}
