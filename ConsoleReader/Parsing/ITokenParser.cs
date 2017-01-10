namespace ConsoleReader.Parsing
{
    public interface ITokenParser<T>
    {
        T Parse(string token);
    }
}
