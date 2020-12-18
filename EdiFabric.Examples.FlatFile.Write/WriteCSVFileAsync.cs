using EdiFabric.Examples.FlatFile.Common;
using EdiFabric.Framework.Writers;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;

namespace EdiFabric.Examples.FlatFile.Write
{
    class WriteCSVFileAsync
    {
        /// <summary>
        /// Generate and write CSV document to a stream async
        /// </summary>
        public static async void Run()
        {
            Debug.WriteLine("******************************");
            Debug.WriteLine(MethodBase.GetCurrentMethod().Name);
            Debug.WriteLine("******************************");

            using (var stream = new MemoryStream())
            {
                using (var writer = new StreamWriter(stream, Encoding.UTF8, 4096, true))
                {
                    using (var flatWriter = new FlatWriter(writer, null, TrialLicense.SerialNumber))
                    {
                        var flatPO = POBuilder.BuildFlatPO();
                        await flatWriter.WriteAsync(flatPO);
                    }

                    Debug.Write(stream.LoadToString());
                }                
            }
        }
    }
}
