namespace EdiFabric.Examples.FlatFile.Console.CSV
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadCSVFile.Run();
            ReadCSVFileAsync.Run();

            WriteCSVFile.Run();
            WriteCSVFileAsync.Run();
        }
    }
}
