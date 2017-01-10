namespace ConsoleReader.Parsing
{
    sealed class Int32TokenParser : ITokenParser<int>
    {
        public int Parse(string token)
        {
            return int.Parse(token);
        }
    }
}
