namespace TypedReader.Parsing
{
    public class BoolTokenParser : ITokenParser<bool>
    {
        public bool Parse(string token)
        {
            var normalized = token.Trim().ToLower();

            if (normalized == "true")
                return true;

            if (normalized == "false")
                return false;

            if (decimal.TryParse(normalized, out var parsed))
                return parsed != 0;

            return false;
        }
    }
}