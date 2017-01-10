namespace ConsoleReader.Parsing
{
    sealed class UInt64TokenParser : TokenParser<ulong>
    {
        public ulong Parse(string token)
        {
            return ulong.Parse(token);
        }
    }
}
