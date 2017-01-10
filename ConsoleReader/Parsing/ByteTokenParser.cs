namespace ConsoleReader.Parsing
{
    sealed class ByteTokenParser : TokenParser<byte>
    {
        public byte Parse(string token)
        {
            return byte.Parse(token);
        }
    }
}
