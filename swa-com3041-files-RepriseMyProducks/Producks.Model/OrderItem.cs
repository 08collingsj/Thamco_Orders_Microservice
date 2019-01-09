using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producks.Model
{
    public class OrderItem
    {
        public virtual int Id { get; set; }
        public virtual string name { get; set; }
        public virtual double unitPrice { get; set; }
        public virtual double discount { get; set; }
        public virtual int units { get; set; }
        public virtual string pictureUrl { get; set; }
    }
}
