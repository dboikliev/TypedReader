namespace ConsoleReader.Parsing
{
    sealed class UInt16TokenParser : TokenParser<ushort>
    {
        public override ushort Parse(string token)
        {
            return ushort.Parse(token);
        }
    }
}
