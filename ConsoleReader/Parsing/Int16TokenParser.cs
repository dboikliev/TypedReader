namespace ConsoleReader.Parsing
{
    sealed class Int16TokenParser : TokenParser<short>
    {
        public override short Parse(string token)
        {
            return short.Parse(token);
        }
    }
}
