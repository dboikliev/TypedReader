namespace ConsoleReader.Parsing
{
    sealed class Int64TokenParser : TokenParser<long>
    {
        public override long Parse(string token)
        {
            return long.Parse(token);
        }
    }
}
