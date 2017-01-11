namespace ConsoleReader.TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Reader.TokenizerOptions.Separator = '|';
            var file1 = Reader.Next<string>();
            var file2 = Reader.Next<string>();
            System.Console.WriteLine($"file1: { file1 }, file2: { file2 }");

        }
    }

}
