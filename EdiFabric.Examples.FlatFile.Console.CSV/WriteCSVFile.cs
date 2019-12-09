using EdiFabric.Examples.FlatFile.Common;
using EdiFabric.Examples.FlatFile.Templates.CSV;
using EdiFabric.Framework.Writers;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;

namespace EdiFabric.Examples.FlatFile.Console.CSV
{
    class WriteCSVFile
    {
        /// <summary>
        /// Generate and write CSV document to a stream
        /// </summary>
        public static void Run()
        {
            Debug.WriteLine("******************************");
            Debug.WriteLine(MethodBase.GetCurrentMethod().Name);
            Debug.WriteLine("******************************");

            using (var stream = new MemoryStream())
            {
                using (var writer = new StreamWriter(stream, Encoding.UTF8, 4096, true))
                {
                    using (var flatWriter = new FlatWriter(writer))
                    {
                        var flatPO = POBuilder.BuildFlatPO();
                        flatWriter.Write(flatPO);
                    }

                    Debug.Write(stream.LoadToString());
                }                
            }
        }
    }
}
