namespace ConsoleReader.Parsing
{
    sealed class Int64TokenParser : ITokenParser<long>
    {
        public long Parse(string token)
        {
            return long.Parse(token);
        }
    }
}
