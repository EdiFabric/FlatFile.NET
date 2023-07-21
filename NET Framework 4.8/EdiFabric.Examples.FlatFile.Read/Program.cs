using EdiFabric.Examples.FlatFile.Common;

namespace EdiFabric.Examples.FlatFile.Read
{
    class Program
    {
        static void Main(string[] args)
        {
            TokenFileCache.Set();

            ReadCSVFile.Run();
            ReadCSVFile.Run2();
            ReadCSVFile.Run3();
            ReadCSVFile.Run4();
            ReadCSVFileAsync.Run();
            ReadCSVFileWithSplitting.Run();
        }
    }
}
