using EdiFabric.Examples.FlatFile.Common;

namespace EdiFabric.Examples.FlatFile.Write
{
    class Program
    {
        static void Main(string[] args)
        {
            SerialKey.Set(Common.SerialKey.Get());
            WriteCSVFile.Run();
            WriteCSVFileAsync.Run();
        }
    }
}
