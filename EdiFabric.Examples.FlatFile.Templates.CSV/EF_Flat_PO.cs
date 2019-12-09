using System;
using System.Collections.Generic;
using EdiFabric.Core.Annotations.Edi;
using EdiFabric.Core.Annotations.Validation;
using EdiFabric.Core.Model.Edi;

namespace EdiFabric.Templates.FlatFile
{
    [Serializable()]
    [Message("Flat", "PO")]
    public class FlatPO : EdiMessage
    {
        [Required]
        [Pos(1)]
        public Header Header { get; set; }

        [Required]
        [Pos(2)]
        public List<Customer> Customers { get; set; }

        [Required]
        [Pos(3)]
        public Items Items { get; set; }        
    }
   
    [Serializable()]
    [Segment("PO")]
    public class Header
    {
        [Required]
        [StringLength(2, 2)]
        [Pos(1)]
        public string Tag { get; set; }

        [Required]
        [StringLength(10, 10, false, ' ')]
        [Pos(2)]
        public string Date { get; set; }       
    }

    [Serializable()]
    [Segment("")]
    public class Customer
    {
        [Required]
        [StringLength(10, 10, false, ' ')]
        [Pos(1)]
        public string Country { get; set; }

        [Required]
        [StringLength(20, 20, false, ' ')]
        [Pos(2)]
        public string FullName { get; set; }

        [Required]
        [StringLength(20, 20, false, ' ')]
        [Pos(3)]
        public string Street { get; set; }

        [Required]
        [StringLength(15, 15, false, ' ')]
        [Pos(4)]
        public string City { get; set; }

        [Required]
        [StringLength(3, 3, false, ' ')]
        [Pos(5)]
        public string State { get; set; }

        [Required]
        [StringLength(5, 5, false, ' ')]
        [Pos(6)]
        public string PostCode { get; set; }
    }

    [Serializable()]
    [Segment("ITEMS", ',', '|')]
    public class Items
    {

        [Pos(1)]
        public string Tag { get; set; }

        [Pos(2)]
        public List<ItemDetail> ItemDetails { get; set; }
    }

    [Serializable()]
    [Composite("ItemDetails")]
    public class ItemDetail
    {
        [Pos(1)]
        public string ProductCode { get; set; }

        [Pos(2)]
        public string Description { get; set; }

        [Pos(3)]
        public string Quantity { get; set; }

        [Pos(4)]
        public string UnitPrice { get; set; }

        [Pos(5)]
        public string Notes { get; set; }
    }
}
