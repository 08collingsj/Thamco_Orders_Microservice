using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orders_Microservice.Dtos
{
    public class DispatchServiceOrder
    {
        public int DispatchId { get; set; }
        public string OrderRef { get; set; }
        public string ProductRef { get; set; }
        public int Quantity { get; set; }
        public string Address { get; set; }

        public DateTime OrderDate { get; set; }
        public DateTime DispatchDate{ get; set; }
    }
}
