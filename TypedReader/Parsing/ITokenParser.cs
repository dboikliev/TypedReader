namespace TypedReader.Parsing
{
    public interface ITokenParser<T>
    {
        T Parse(string token);
    }
}
