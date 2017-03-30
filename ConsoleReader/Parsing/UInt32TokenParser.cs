namespace ConsoleReader.Parsing
{
    internal sealed class UInt32TokenParser : ITokenParser<uint>
    {
        public uint Parse(string token)
        {
            return uint.Parse(token);
        }
    }
}
