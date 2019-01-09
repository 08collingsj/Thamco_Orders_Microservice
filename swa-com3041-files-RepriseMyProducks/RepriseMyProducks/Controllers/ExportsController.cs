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
    public class ExportsController : ApiController
    {
        private Producks.Model.StoreDb db = new Producks.Model.StoreDb();
        
        // GET: api/Brands
        [HttpGet]
        [Route("api/Brands")]
        public IEnumerable<Dtos.Brand> GetBrands()
        {
            return db.Brands
                     .AsEnumerable()
                     .Select(b => new Dtos.Brand
                     {
                        Id = b.Id,
                        Name = b.Name,
                        Active = b.Active
                     });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}