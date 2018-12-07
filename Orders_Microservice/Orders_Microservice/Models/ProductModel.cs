using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orders_Microservice.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

        public double ProductPurchasePrice { get; set; }
    }
}
