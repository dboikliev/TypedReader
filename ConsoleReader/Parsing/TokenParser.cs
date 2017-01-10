namespace ConsoleReader.Parsing
{
    public interface TokenParser<T>
    {
        T Parse(string token);
    }
}
