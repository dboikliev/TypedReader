namespace ConsoleReader.Parsing
{
    sealed class Int32TokenParser : TokenParser<int>
    {
        public override int Parse(string token)
        {
            return int.Parse(token);
        }
    }
}
