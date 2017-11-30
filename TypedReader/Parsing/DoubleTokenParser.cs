namespace TypedReader.Parsing
{
    internal sealed class DoubleTokenParser : ITokenParser<double>
    {
        public double Parse(string token)
        {
            return double.Parse(token);
        }
    }
}
