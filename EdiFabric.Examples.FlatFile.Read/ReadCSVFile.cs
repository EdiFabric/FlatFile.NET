using EdiFabric.Framework.Readers;
using EdiFabric.Examples.FlatFile.Common;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;

namespace EdiFabric.Examples.FlatFile.Read
{
    class ReadCSVFile
    {
        /// <summary>
        /// Reads custom CSV file into the template.
        /// </summary>
        public static void Run()
        {
            Debug.WriteLine("******************************");
            Debug.WriteLine(MethodBase.GetCurrentMethod().Name);
            Debug.WriteLine("******************************");

            Stream ediStream = File.OpenRead(Directory.GetCurrentDirectory() + @"\..\..\..\Files\Flat_PO.txt");

            using (StreamReader streamReader = new StreamReader(ediStream, Encoding.UTF8, true, 1024))
            {
                using (var csvReader = new FlatReader(streamReader, typeof(FlatPO)))
                {
                    var result = csvReader.ReadToEnd() as FlatPO;
                }
            }
        }

        /// <summary>
        /// Reads custom CSV file into the template.
        /// </summary>
        public static void Run2()
        {
            Debug.WriteLine("******************************");
            Debug.WriteLine(MethodBase.GetCurrentMethod().Name);
            Debug.WriteLine("******************************");

            Stream ediStream = File.OpenRead(Directory.GetCurrentDirectory() + @"\..\..\..\Files\Flat_Markers.txt");

            using (StreamReader streamReader = new StreamReader(ediStream, Encoding.UTF8, true, 1024))
            {
                using (var csvReader = new FlatReader(streamReader, typeof(FlatMarkers)))
                {
                    var result = csvReader.ReadToEnd() as FlatMarkers;
                }
            }
        }
    }
}
