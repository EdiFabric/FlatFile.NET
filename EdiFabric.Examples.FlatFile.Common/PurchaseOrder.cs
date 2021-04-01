using EdiFabric.Core.Annotations.Edi;
using EdiFabric.Core.Annotations.Validation;
using EdiFabric.Core.Model.Edi;
using System;
using System.Collections.Generic;

namespace EdiFabric.Examples.X12.MapEDI
{
    [Serializable()]
    [Message("Flat", "PurchaseOrder")]
    public class PurchaseOrder : EdiMessage
    {
        [Required]
        [Pos(1)]
        public Header Header { get; set; }

        [Required]
        [Pos(2)]
        public List<Item> Items { get; set; }
    }

    [Serializable()]
    [Segment("LINE_NUMBER", '\0')]
    public class Header
    {
        [Required]
        [Pos(1)]
        public string Data { get; set; }
    }

    [Serializable()]
    [Segment("", ',')]
    public class Item
    {
        [Pos(1)]
        public string LineNumber { get; set; }
        [Pos(2)]
        public string UPCNumber { get; set; }
        [Pos(3)]
        public string Quantity { get; set; }
        [Pos(4)]
        public string Price { get; set; }
        [Pos(5)]
        public string UOM { get; set; }
        [Pos(6)]
        public string PONumber { get; set; }
        [Pos(7)]
        public string PODate { get; set; }
        [Pos(8)]
        public string CustomerName { get; set; }
        [Pos(9)]
        public string CustomerNumber { get; set; }
        [Pos(10)]
        public string AddressLine { get; set; }
        [Pos(11)]
        public string City { get; set; }
        [Pos(12)]
        public string State { get; set; }
        [Pos(13)]
        public string PostCode { get; set; }
    }
}
