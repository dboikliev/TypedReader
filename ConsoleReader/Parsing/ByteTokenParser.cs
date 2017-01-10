namespace ConsoleReader.Parsing
{
    sealed class ByteTokenParser : ITokenParser<byte>
    {
        public byte Parse(string token)
        {
            return byte.Parse(token);
        }
    }
}
