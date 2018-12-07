using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orders_Microservice.Models
{
    public class CustomerModel
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }

        public IEnumerable<OrderModel> CustomerOrdersList { get; set; }

        public double CustomerReferalBalance { get; set; }
    }
}
