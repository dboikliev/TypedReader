namespace ConsoleReader.Parsing
{
    sealed class UInt64TokenParser : TokenParser<ulong>
    {
        public override ulong Parse(string token)
        {
            return ulong.Parse(token);
        }
    }
}
