using EdiFabric.Framework.Readers;
using EdiFabric.Templates.Vda;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;

namespace EdiFabric.Examples.FlatFile.Console.VDA
{
    class ReadVDAFile
    {
        /// <summary>
        /// Reads VDA file into the template.
        /// </summary>
        public static void Run()
        {
            Debug.WriteLine("******************************");
            Debug.WriteLine(MethodBase.GetCurrentMethod().Name);
            Debug.WriteLine("******************************");

            Stream ediStream = File.OpenRead(Directory.GetCurrentDirectory() + @"\..\..\..\Files\VDA\Vda_4905_02.txt");

            using (StreamReader streamReader = new StreamReader(ediStream, Encoding.UTF8, true, 1024))
            {
                using (var vdaReader = new FlatReader(streamReader, typeof(TS4905)))
                {
                    var result = vdaReader.ReadToEnd() as TS4905;
                }
            }
        }
    }
}
