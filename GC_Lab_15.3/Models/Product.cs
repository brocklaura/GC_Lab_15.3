using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GC_Lab_15._3.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public int QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
