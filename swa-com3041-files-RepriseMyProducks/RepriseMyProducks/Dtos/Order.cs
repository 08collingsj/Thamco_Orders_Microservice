﻿using Producks.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepriseMyProducks.Dtos
{
    public class Order
    {
        public virtual int Id { get; set; }
        public virtual DateTime OrderDate { get; set; }
        public virtual string Status { get; set; }
        public virtual double Total { get; set; }
        public virtual string description { get; set; }
        public virtual List<OrderItem> OrderItems { get; set; }

        public virtual string street { get; set; }
        public virtual string postCode { get; set; }
        public virtual string Country { get; set; }

        public virtual Card OrderCard { get; set; }
    }
}