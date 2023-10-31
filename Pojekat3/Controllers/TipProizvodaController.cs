using PagedList;
using Pojekat3.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pojekat3.Controllers
{
    public class TipProizvodaController : Controller
    {
        private Model1 db = new Model1();
        public ActionResult Index(string pretraga)
        {
            var model = db.TipProizvoda_set
                        .Where(s => pretraga == null || s.Vrsta.Contains(pretraga))
                        .ToList();

            return View(model);

        }

        [Authorize(Users = "ana@gmail.com, nina@gmail.com")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TipProizvodaID, Vrsta")] TipProizvoda tipProizvoda)
        {
            if (ModelState.IsValid)
            {
                db.TipProizvoda_set.Add(tipProizvoda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipProizvoda);
        }

        [Authorize(Users = "ana@gmail.com, nina@gmail.com")]
        public ActionResult Edit(int id)
        {
            TipProizvoda tipProizvoda = db.TipProizvoda_set.Find(id);
            return View(tipProizvoda);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TipProizvodaID, Vrsta")] TipProizvoda tipProizvoda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipProizvoda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipProizvoda);
        }

        [Authorize(Users = "ana@gmail.com, nina@gmail.com")]
        public ActionResult Delete(int id)
        {
            TipProizvoda tipProizvoda = db.TipProizvoda_set.Find(id);
            return View(tipProizvoda);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipProizvoda tipProizvoda = db.TipProizvoda_set.Find(id);
            db.TipProizvoda_set.Remove(tipProizvoda);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            TipProizvoda tipProizvoda = db.TipProizvoda_set.Find(id);
            return View(tipProizvoda);

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