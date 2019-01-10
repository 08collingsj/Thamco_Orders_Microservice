using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producks.Model
{
    public class Invite
    {
        public virtual int Id { get; set; }
        public virtual DateTime sendDate { get; set; }
        public virtual DateTime expirationDate { get; set; }
        public virtual int userFrom { get; set; }
        public virtual string emailTo { get; set; }
        public virtual bool isAccepted { get; set; }
    }
}
