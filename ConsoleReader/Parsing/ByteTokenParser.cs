namespace ConsoleReader.Parsing
{
    sealed class ByteTokenParser : TokenParser<byte>
    {
        public override byte Parse(string token)
        {
            return byte.Parse(token);
        }
    }
}
