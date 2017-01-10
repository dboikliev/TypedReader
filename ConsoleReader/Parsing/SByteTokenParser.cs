namespace ConsoleReader.Parsing
{
    sealed class SByteTokenParser : TokenParser<sbyte>
    {
        public sbyte Parse(string token)
        {
            return sbyte.Parse(token);
        }
    }
}
