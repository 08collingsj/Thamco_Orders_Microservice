using Producks.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace RepriseMyProducks.Controllers
{
    public class OrderItemsController : Controller
    {
        private OrderDb db = new OrderDb();
        // GET: OrderItems
        public ActionResult Index()
        {
            return View(db.OrderItems.ToList());
        }

        // GET: OrderItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderItem item = db.OrderItems.Find(id);
            if (item == null)
                return HttpNotFound();

            return View();
        }

        // GET: OrderItems/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderItems/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id, name, unitPrice, discount, units, pictureUrl")] OrderItem item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.OrderItems.Add(item);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(item);
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            OrderItem item = db.OrderItems.Find(id);
            if (item == null)
                return HttpNotFound();

            return View(item);
        }

        // POST: OrderItems/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, name, unitPrice, discount, units, pictureUrl")] OrderItem item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(item).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(item);
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderItem item = db.OrderItems.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: OrderItems/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            OrderItem item = db.OrderItems.Find(id);
            db.OrderItems.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Index");
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
