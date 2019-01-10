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
                         OrderItems = b.OrderItems,
                         street = b.street,
                         postCode = b.postCode,
                         Country = b.Country,
                         OrderCard = b.OrderCard
                     });
        }

        //Allow a user to retrieve their orders
        //[Route("api/Orders/{userId:int}")]
        //[HttpGet]
        //public IEnumerable<Dtos.Order> GetOrdersByUser(int userId)
        //{
        //    return db.Orders
        //        .AsEnumerable()
        //        .Select(x => new Dtos.Order
        //        {
        //            Id = x.Id,
        //            OrderDate = x.OrderDate,
        //            OrderItems = GetOrderItemByOrderId(Id),
        //            Total = x.Total,
        //            Status = x.Status
        //        }).Where(x => x.Id == userId);
        //}


        [HttpGet]
        [Route("api/Order/{OrderId:int}")]
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
                         //Order-Items = b.Order-Items,
                         street = b.street,
                         postCode = b.postCode,
                         Country = b.Country,
                         OrderCard = b.OrderCard
                     }).Where (b => b.Id == OrderId);
        }
        [Route("api/OrderItems")]
        [HttpGet]
        public IEnumerable<Dtos.Order_Item> GetAllOrder_Items()
        {
            return db.OrderItems
                .AsEnumerable()
                .Select(b => new Dtos.Order_Item
                {
                    Id = b.Id,
                    name = b.name,
                    unitPrice = b.unitPrice,
                    units = b.units,
                    pictureUrl = b.pictureUrl
                });
        }
        //Functionality: View their order history and status of each order
        [Route("api/OrderItems/{name:string}")]
        [HttpGet]
        public IEnumerable<Dtos.Order_Item> GetOrder_ItemByName(string name)
        {
            return db.OrderItems
                .AsEnumerable()
                .Select(b => new Dtos.Order_Item
                {
                    Id = b.Id,
                    name = b.name,
                    unitPrice = b.unitPrice,
                    units = b.units,
                    pictureUrl = b.pictureUrl
                }).Where(b => b.name == name);
        }

        [Route("api/OrderItems/{orderId:int}")]
        [HttpGet]
        public IEnumerable<Dtos.Order_Item> GetOrderItemByOrderId(int orderId)
        {
            return db.OrderItems
                .AsEnumerable()
                .Select(b => new Dtos.Order_Item
                {
                    Id = b.Id,
                    name = b.name,
                    unitPrice = b.unitPrice,
                    units = b.units,
                    pictureUrl = b.pictureUrl
                }).Where(b => b.OrderId == orderId);
        }

        //Purchase a product subject to stock availability.
        //A delivery address must be provided

        //[HttpPost]
        //public IHttpActionResult SendInviteToUser(int? currentUserId, string sendInviteToEmail)
        //{
        //    try
        //    {
        //        if (currentUserId != null && sendInviteToEmail != null)
        //        {
        //            return View(InvitationSent);
        //        }
        //        else
        //            return HttpStatusCode.BadRequest;

        //    }
        //    catch (Exception ex)
        //    {

        //        Console.WriteLine("Exception caught: " + ex.Message);
        //        return HttpStatusCode.BadRequest;
        //    }

        //}


    }
}