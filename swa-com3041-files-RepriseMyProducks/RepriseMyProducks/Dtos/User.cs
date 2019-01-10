using Producks.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepriseMyProducks.Dtos
{
    public class User
    {
        public virtual int UserID { get; set; }
        public virtual string Street { get; set; }
        public virtual string PostCode { get; set; }
        public virtual string Country { get; set; }
        public virtual List<Invite> InviteList { get; set; }
        public virtual double ReferalBalance { get; set; }
        public virtual string Email { get; set; }
        public virtual string UserType { get; set; } //Staff / manager /user
        public virtual List<FakeMessage> MessageList { get; set; }
        public virtual Card card { get; set; }
    }
}