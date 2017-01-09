namespace ConsoleReader.Parsing
{
    sealed class SByteTokenParser : TokenParser<sbyte>
    {
        public override sbyte Parse(string token)
        {
            return sbyte.Parse(token);
        }
    }
}
