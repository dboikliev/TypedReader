namespace ConsoleReader.Parsing
{
    sealed class DecimalTokenParser : ITokenParser<decimal>
    {
        public decimal Parse(string token)
        {
            return decimal.Parse(token);
        }
    }
}
