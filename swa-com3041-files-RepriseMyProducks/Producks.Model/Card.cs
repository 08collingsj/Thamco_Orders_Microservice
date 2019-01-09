using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producks.Model
{
    public class Card
    {
        public virtual int Id { get; set; }
        public virtual string HolderName { get; set; }

        public virtual int CardNumber { get; set; }
        public virtual DateTime CardExpiration { get; set; }
        public virtual string SecurityNumber { get; set; }

    }
}
