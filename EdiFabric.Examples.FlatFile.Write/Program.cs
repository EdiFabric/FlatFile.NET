using EdiFabric.Examples.FlatFile.Common;

namespace EdiFabric.Examples.FlatFile.Write
{
    class Program
    {
        static void Main(string[] args)
        {
            SerialKey.Set(TrialLicense.SerialKey);
            WriteCSVFile.Run();
            WriteCSVFileAsync.Run();
        }
    }
}
