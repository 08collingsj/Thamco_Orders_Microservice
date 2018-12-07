using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orders_Microservice.Models
{
    public class OrderModel
    {
        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        public IEnumerable<ProductModel> ProductIdList { get; set; }

        public DateTime OrderDate { get; set; }

        //Was an Id but changed to string to prevent normalising across another table
        public string OrderState { get; set; }

        public double OrderValue { get; set; }

        public bool UsingReferal { get; set; }

        
    }
}
