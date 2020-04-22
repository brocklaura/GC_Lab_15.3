using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GC_Lab_15._3.Models
{
    public class OrderShipment
    {
        //OrderID, CustomerID, OrderDate, ShippedDate, ShipName, ShipAddress, ShipCity, ShipPostalCode, ShipRegion, ShipCountry 
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipRegion { get; set; }
        public string ShipCountry { get; set; }
    }
}
