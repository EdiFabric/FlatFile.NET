using EdiFabric.Examples.FlatFile.Common;

namespace EdiFabric.Examples.FlatFile.Read
{
    class Program
    {
        static void Main(string[] args)
        {
            SerialKey.Set(TrialLicense.SerialKey);

            ReadCSVFile.Run();
            ReadCSVFile.Run2();
            ReadCSVFileAsync.Run();           
        }
    }
}
