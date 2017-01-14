namespace ConsoleReader.Parsing
{
    sealed class StringTokenParser : ITokenParser<string>
    {
        public string Parse(string token)
        {
            return token;
        }
    }
}
