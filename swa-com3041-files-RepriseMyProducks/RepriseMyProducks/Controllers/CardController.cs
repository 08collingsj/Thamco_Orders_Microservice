using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Producks.Model;

namespace RepriseMyProducks.Controllers
{
    public class CardController : Controller
    {
        private OrderDb db = new OrderDb();
        // GET: Card
        public ActionResult Index()
        {
            return View(db.Cards.ToList());
        }

        // GET: Card/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Card card = db.Cards.Find(id);
            if (card == null)
                return HttpNotFound();

            return View();
        }

        // GET: Card/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Card/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id, HolderName, CardNumber, CardExpiration, SecurityNumber")] Card card)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Cards.Add(card);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(card);
            }
            catch
            {
                return View();
            }
        }

        // GET: Card/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Card card = db.Cards.Find(id);
            if (card == null)
                return HttpNotFound();

            return View(card);
        }

        // POST: Card/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, HolderName, CardNumber,CardExpiration, SecurityNumber")] Card card)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(card).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(card);
            }
            catch
            {
                return View();
            }
        }

        // GET: Card/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Card card = db.Cards.Find(id);
            if (card == null)
            {
                return HttpNotFound();
            }
            return View(card);
        }

        // POST: Card/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Card card = db.Cards.Find(id);
            db.Cards.Remove(card);
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
