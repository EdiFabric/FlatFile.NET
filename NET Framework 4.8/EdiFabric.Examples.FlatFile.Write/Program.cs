using EdiFabric.Examples.FlatFile.Common;

namespace EdiFabric.Examples.FlatFile.Write
{
    class Program
    {
        static void Main(string[] args)
        {
            TokenFileCache.Set();
            WriteCSVFile.Run();
            WriteCSVFileAsync.Run();
        }
    }
}
