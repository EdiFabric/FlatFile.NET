using System.Collections.Generic;

namespace EdiFabric.Examples.FlatFile.Common
{
    public class POBuilder
    {
        /// <summary>
        /// Build Flat PO.
        /// </summary>
        public static FlatPO BuildFlatPO()
        {
            var result = new FlatPO();

            //  Header
            result.Header = new Header();
            result.Header.Tag = "PO";
            result.Header.Date = "2019-12-17";

            //  Customers
            result.Customers = new List<Customer>();

            //  Customer 1
            var customer1 = new Customer();
            customer1.FullName = "David Pastrnak"; 
            customer1.Street = "100 Legends Way";
            customer1.City = "Boston";
            customer1.PostCode = "02114";
            customer1.State = "MA";
            customer1.Country = "US";
            result.Customers.Add(customer1);

            //  Customer 2
            var customer2 = new Customer();
            customer2.FullName = "Nathan MacKinnon";
            customer2.Street = "1000 Chopper Cir";
            customer2.City = "Denver";
            customer2.PostCode = "80204";
            customer2.State = "CO";
            customer2.Country = "US";
            result.Customers.Add(customer2);

            //  Items
            result.Items = new Items();
            result.Items.Tag = "ITEMS";
            result.Items.ItemDetails = new List<ItemDetail>();

            //  Item 1
            var item1 = new ItemDetail();
            item1.Description = "Bauer Nexus 2N Pro";
            item1.ProductCode = "ITEM213-CC";
            item1.Quantity = "1";
            item1.UnitPrice = "168.95";
            item1.Notes = "Hockey stick";
            result.Items.ItemDetails.Add(item1);

            //  Item 2
            var item2 = new ItemDetail();
            item2.Description = "CCM RibCor 70K";
            item2.ProductCode = "ITEM323-CC";
            item2.Quantity = "1";
            item2.UnitPrice = "500.98";
            item2.Notes = "Hockey skates";
            result.Items.ItemDetails.Add(item2);

            return result;
        }
    }
}
