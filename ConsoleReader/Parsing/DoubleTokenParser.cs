namespace ConsoleReader.Parsing
{
    sealed class DoubleTokenParser : ITokenParser<double>
    {
        public double Parse(string token)
        {
            return double.Parse(token);
        }
    }
}
