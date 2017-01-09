namespace ConsoleReader.Parsing
{
    public abstract class TokenParser<T>
    {
        public abstract T Parse(string token);
    }
}
