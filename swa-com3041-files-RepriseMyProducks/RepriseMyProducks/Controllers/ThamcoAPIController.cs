using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace RepriseMyProducks.Controllers
{
    public class ThamcoAPIController : ApiController
    {
        private Producks.Model.OrderDb db = new Producks.Model.OrderDb();
        // GET: ThamcoAPI
        // GET: api/Brands
        [HttpGet]
        [Route("api/Orders")]
        public IEnumerable<Dtos.Order> GetOrders()
        {
            return db.Orders
                     .AsEnumerable()
                     .Select(b => new Dtos.Order
                     {
                         Id = b.Id,
                         OrderDate = b.OrderDate,
                         Status = b.Status,
                         Total = b.Total,
                         description = b.description,
                         //OrderItems = b.OrderItems,
                         street = b.street,
                         postCode = b.postCode,
                         Country = b.Country,
                         OrderCard = b.OrderCard
                     });
        }

        [HttpGet]
        [Route("api/Order/5")]
        public IEnumerable<Dtos.Order> GetOrderByOrderId(int OrderId)
        {
            return db.Orders
                     .AsEnumerable()
                     .Select(b => new Dtos.Order
                     {
                         Id = b.Id,
                         OrderDate = b.OrderDate,
                         Status = b.Status,
                         Total = b.Total,
                         description = b.description,
                         //OrderItems = b.OrderItems,
                         street = b.street,
                         postCode = b.postCode,
                         Country = b.Country,
                         OrderCard = b.OrderCard
                     }).Where (b => b.Id == OrderId);
        }
    }
}