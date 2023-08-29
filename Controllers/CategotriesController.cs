using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication31.Models;

namespace WebApplication31.Controllers
{
    public class CategotriesController : Controller
    {
        private Training1Entities db = new Training1Entities();

        // GET: Categotries
        public ActionResult Index()
        {
            return View(db.Categotries.ToList());
        }

        // GET: Categotries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categotry categotry = db.Categotries.Find(id);
            if (categotry == null)
            {
                return HttpNotFound();
            }
            return View(categotry);
        }

        // GET: Categotries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categotries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryID,CategoryName,CategorySalePrice,CategoryBuyPrice")] Categotry categotry)
        {
            if (ModelState.IsValid)
            {
                db.Categotries.Add(categotry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categotry);
        }

        // GET: Categotries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categotry categotry = db.Categotries.Find(id);
            if (categotry == null)
            {
                return HttpNotFound();
            }
            return View(categotry);
        }

        // POST: Categotries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryID,CategoryName,CategorySalePrice,CategoryBuyPrice")] Categotry categotry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categotry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categotry);
        }

        // GET: Categotries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categotry categotry = db.Categotries.Find(id);
            if (categotry == null)
            {
                return HttpNotFound();
            }
            return View(categotry);
        }

        // POST: Categotries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Categotry categotry = db.Categotries.Find(id);
            db.Categotries.Remove(categotry);
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
