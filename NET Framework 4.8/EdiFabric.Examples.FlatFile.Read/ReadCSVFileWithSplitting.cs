using EdiFabric.Framework.Readers;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using EdiFabric.Core.Model.Edi;
using System.Collections.Generic;
using EdiFabric.Framework;
using EdiFabric.Core.Annotations.Edi;
using System;
using EdiFabric.Examples.FlatFile.Common;
using EdiFabric.Core.Annotations.Validation;

namespace EdiFabric.Examples.FlatFile.Read
{
    class ReadCSVFileWithSplitting
    {
        /// <summary>
        /// Split a message into parts (blocks of segments) and read each part individually.
        /// </summary>
        public static void Run()
        {
            Debug.WriteLine("******************************");
            Debug.WriteLine(MethodBase.GetCurrentMethod().Name);
            Debug.WriteLine("******************************");

            Stream ediStream = File.OpenRead(Directory.GetCurrentDirectory() + Config.TestFilesPath + @"\Flat_Split.txt");
            List<IEdiItem> items = new List<IEdiItem>();

            using (StreamReader streamReader = new StreamReader(ediStream, Encoding.UTF8, true, 1024))
            {
                using (var flatReader = new FlatReader(streamReader, FlatFactory, new FlatReaderSettings { Split = true }))
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
                    return new MessageContext("PO", "Flat", mc => Assembly.Load(new AssemblyName("EdiFabric.Examples.FlatFile.Read")));
            }

            return null;
        }
    }

    [Serializable()]
    [Message("Flat", "PO")]
    public class FlatPOSplitter : FlatPO
    {
        [Splitter]
        [Required]
        [Pos(2)]
        public new List<Customer> Customers { get; set; }
    }
}
