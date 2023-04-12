using EdiFabric.Framework.Readers;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using EdiFabric.Core.Model.Edi;
using System.Collections.Generic;
using EdiFabric.Framework;
using EdiFabric.Examples.FlatFile.Common;

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

            Stream ediStream = File.OpenRead(Directory.GetCurrentDirectory() + Config.TestFilesPath + @"\Flat_PO.txt");
            List<IEdiItem> items = new List<IEdiItem>();

            using (StreamReader streamReader = new StreamReader(ediStream, Encoding.UTF8, true, 1024))
            {
                using (var flatReader = new FlatReader(streamReader, FlatFactory))
                {
                    while (flatReader.Read())
                    {
                        items.Add(flatReader.Item);
                    }
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

            Stream ediStream = File.OpenRead(Directory.GetCurrentDirectory() + Config.TestFilesPath + @"\Flat_Markers.txt");
            List<IEdiItem> items = new List<IEdiItem>();

            using (StreamReader streamReader = new StreamReader(ediStream, Encoding.UTF8, true, 1024))
            {
                using (var flatReader = new FlatReader(streamReader, FlatFactory))
                {
                    while (flatReader.Read())
                    {
                        items.Add(flatReader.Item);
                    }
                }
            }
        }

        /// <summary>
        /// Reads custom CSV file with multiple messages into templates.
        /// The messages can be of any type.
        /// </summary>
        public static void Run3()
        {
            Debug.WriteLine("******************************");
            Debug.WriteLine(MethodBase.GetCurrentMethod().Name);
            Debug.WriteLine("******************************");

            Stream ediStream = File.OpenRead(Directory.GetCurrentDirectory() + Config.TestFilesPath + @"\Flat_Multiple.txt");
            List<IEdiItem> items = new List<IEdiItem>();

            using (StreamReader streamReader = new StreamReader(ediStream, Encoding.UTF8, true, 1024))
            {
                using (var flatReader = new FlatReader(streamReader, FlatFactory))
                {
                    while (flatReader.Read())
                    {
                        items.Add(flatReader.Item);
                    }
                }
            }
        }

        /// <summary>
        /// Reads custom CSV file.
        /// </summary>
        public static void Run4()
        {
            Debug.WriteLine("******************************");
            Debug.WriteLine(MethodBase.GetCurrentMethod().Name);
            Debug.WriteLine("******************************");

            Stream ediStream = File.OpenRead(Directory.GetCurrentDirectory() + Config.TestFilesPath + @"\CSV_PO.txt");
            List<IEdiItem> items = new List<IEdiItem>();

            using (StreamReader streamReader = new StreamReader(ediStream, Encoding.UTF8, true, 1024))
            {
                using (var flatReader = new FlatReader(streamReader, FlatFactory))
                {
                    while (flatReader.Read())
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
                case "LI":
                    return new MessageContext("PurchaseOrder", "Flat", mc => Assembly.Load(new AssemblyName("EdiFabric.Examples.FlatFile.Common")));
            }

            return null;
        }
    }
}
