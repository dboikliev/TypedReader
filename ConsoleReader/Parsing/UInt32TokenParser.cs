namespace ConsoleReader.Parsing
{
    sealed class UInt32TokenParser : TokenParser<uint>
    {
        public override uint Parse(string token)
        {
            return uint.Parse(token);
        }
    }
}
