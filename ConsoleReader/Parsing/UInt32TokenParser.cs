namespace ConsoleReader.Parsing
{
    sealed class UInt32TokenParser : TokenParser<uint>
    {
        public uint Parse(string token)
        {
            return uint.Parse(token);
        }
    }
}
