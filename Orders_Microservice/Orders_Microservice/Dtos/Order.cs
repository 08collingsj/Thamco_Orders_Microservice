using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orders_Microservice.Dtos
{
    public class Order
    {
        public int OrderId { get;set; }
        public int ProductId { get; set; }

        public DateTime OrderDate { get; set; }
    
        public int OrderStateId { get; set; }


    }
}
