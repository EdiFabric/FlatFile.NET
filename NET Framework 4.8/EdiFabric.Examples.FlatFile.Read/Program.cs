using EdiFabric.Examples.FlatFile.Common;

namespace EdiFabric.Examples.FlatFile.Read
{
    class Program
    {
        static void Main(string[] args)
        {
            SerialKey.Set(Config.TrialSerialKey);
            //  Uncomment and then comment out the line above if you wish to use distributed cache for tokens
            //   SerialKey.Set(Config.TrialSerialKey);

            ReadCSVFile.Run();
            ReadCSVFile.Run2();
            ReadCSVFile.Run3();
            ReadCSVFile.Run4();
            ReadCSVFileAsync.Run();
            ReadCSVFileWithSplitting.Run();
        }
    }
}
