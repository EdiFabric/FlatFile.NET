using EdiFabric.Examples.FlatFile.Common;
using EdiFabric.Examples.FlatFile.Templates.VDA;
using EdiFabric.Framework.Writers;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;

namespace EdiFabric.Examples.FlatFile.Console.VDA
{
    class WriteVDAFileAsync
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
                    using (var vdaWriter = new FlatWriter(writer))
                    {
                        var ts4905 = TS4905Builder.BuildDeliveryInstruction();
                        await vdaWriter.WriteAsync(ts4905);
                    }

                    Debug.Write(stream.LoadToString());
                }
            }
        }
    }
}
