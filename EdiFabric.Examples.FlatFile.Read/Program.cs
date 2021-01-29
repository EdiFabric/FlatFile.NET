using EdiFabric.Examples.FlatFile.Common;

namespace EdiFabric.Examples.FlatFile.Read
{
    class Program
    {
        static void Main(string[] args)
        {
            SerialKey.Set(Common.SerialKey.Get());

            ReadCSVFile.Run();
            ReadCSVFile.Run2();
            ReadCSVFile.Run3();
            ReadCSVFileAsync.Run();
            ReadCSVFileWithSplitting.Run();
        }
    }
}
