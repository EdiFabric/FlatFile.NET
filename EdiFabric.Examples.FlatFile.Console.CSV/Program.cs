namespace EdiFabric.Examples.FlatFile.Console.CSV
{
    class Program
    {
        static void Main(string[] args)
        {
            //ReadCSVFile.Run();
            ReadCSVFile.Run2();
            ReadCSVFileAsync.Run();

            WriteCSVFile.Run();
            WriteCSVFileAsync.Run();
        }
    }
}
