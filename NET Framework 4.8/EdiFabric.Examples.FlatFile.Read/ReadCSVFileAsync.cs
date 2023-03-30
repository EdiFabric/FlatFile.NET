using EdiFabric.Framework.Readers;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using EdiFabric.Core.Model.Edi;
using System.Collections.Generic;
using EdiFabric.Framework;

namespace EdiFabric.Examples.FlatFile.Read
{
    class ReadCSVFileAsync
    {
        /// <summary>
        /// Reads custom CSV file into the template async.
        /// </summary>
        public static async void Run()
        {
            Debug.WriteLine("******************************");
            Debug.WriteLine(MethodBase.GetCurrentMethod().Name);
            Debug.WriteLine("******************************");

            Stream ediStream = File.OpenRead(Directory.GetCurrentDirectory() + @"\..\..\..\Files\Flat_PO.txt");
            List<IEdiItem> items = new List<IEdiItem>();

            using (StreamReader streamReader = new StreamReader(ediStream, Encoding.UTF8, true, 1024))
            {
                using (var flatReader = new FlatReader(streamReader, FlatFactory))
                {
                    while (await flatReader.ReadAsync())
                    {
                        items.Add(flatReader.Item);
                    }
                }
            }
        }

        private static MessageContext FlatFactory(string segment)
        {
            var id = segment.Substring(0, 2);
            switch (id)
            {
                case "PO":
                    return new MessageContext("PO", "Flat", mc => Assembly.Load(new AssemblyName("EdiFabric.Examples.FlatFile.Common")));
                case "H,":
                    return new MessageContext("Markers", "Flat", mc => Assembly.Load(new AssemblyName("EdiFabric.Examples.FlatFile.Common")));
            }

            return null;
        }
    }
}
