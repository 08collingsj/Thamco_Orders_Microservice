using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producks.Model
{
    public class FakeMessage
    {
        public virtual int Id { get; set; }
        public virtual int FromUserId { get; set; }
        public virtual int ToUserId { get; set; }
        public virtual string Message { get; set; }
        public virtual int PreviousMessageId { get; set; }
        public virtual DateTime MessageSent { get; set; }
    }
}
