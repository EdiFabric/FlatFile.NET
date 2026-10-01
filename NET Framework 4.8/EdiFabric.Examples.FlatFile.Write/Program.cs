using EdiFabric.Examples.FlatFile.Common;
using System;

namespace EdiFabric.Examples.FlatFile.Write
{
    class Program
    {
        static void Main(string[] args)
        {
            License.SetSerial(Config.TrialSerialKey);
            //  Uncomment and then comment out the line above if you wish to use distributed cache for tokens
            //  TokenFileCache.Set();
            WriteCSVFile.Run();
            WriteCSVFileAsync.Run();
        }
    }
}
