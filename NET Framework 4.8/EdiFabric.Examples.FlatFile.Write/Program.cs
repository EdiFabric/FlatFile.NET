using EdiFabric.Examples.FlatFile.Common;

namespace EdiFabric.Examples.FlatFile.Write
{
    class Program
    {
        static void Main(string[] args)
        {
            SerialKey.Set(Config.TrialSerialKey);
            WriteCSVFile.Run();
            WriteCSVFileAsync.Run();
        }
    }
}
