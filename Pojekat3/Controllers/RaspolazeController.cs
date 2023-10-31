
using Pojekat3.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pojekat3.Controllers
{
    [Authorize]
    public class RaspolazeController : Controller
    {
        private Model1 db = new Model1();
        public ActionResult Index(string pretraga)
        {
            var model = db.Raspolaze_set
                        .Where(s => pretraga == null || s.Proizvod.NazivProizvoda.StartsWith(pretraga))
                        .OrderBy(s => s.CenaProizvoda)
                        .ToList();

            return View(model);
        }


        [Authorize(Users = "ana@gmail.com, nina@gmail.com")]
        public ActionResult Create()
        {
            ViewBag.DrogerijaID = new SelectList(db.Drogerija_set, "DrogerijaID", "Naziv");
            ViewBag.ProizvodID = new SelectList(db.Proizvod_set, "ProizvodID", "NazivProizvoda");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RaspolazeID, NazivProizvoda, StatusRaspolozivosti, CenaProizvoda, Kolicina, ProizvodID, DrogerijaID")] Raspolaze raspolaze)
        {
            if (ModelState.IsValid)
            {
                db.Raspolaze_set.Add(raspolaze);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProizvodID = new SelectList(db.Proizvod_set, "ProizvodID", "NazivProizvoda", raspolaze.ProizvodID);
            ViewBag.DrogerijaID = new SelectList(db.Drogerija_set, "DrogerijaID", "Naziv", raspolaze.DrogerijaID);

            return View(raspolaze);
        }

        [Authorize(Users = "ana@gmail.com, nina@gmail.com")]
        public ActionResult Edit(int id)
        {
            Raspolaze raspolaze = db.Raspolaze_set.Find(id);
            ViewBag.ProizvodID = new SelectList(db.Proizvod_set, "ProizvodID", "NazivProizvoda", raspolaze.ProizvodID);
            ViewBag.DrogerijaId = new SelectList(db.Drogerija_set, "DrogerijaID", "Naziv", raspolaze.DrogerijaID);
            return View(raspolaze);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RaspolazeID, NazivProizvoda, Naziv, StatusRaspolozivosti, SifraProizvoda, CenaProizvoda, Kolicina, ProizvodID, DrogerijaID")] Raspolaze raspolaze)
        {
            if (ModelState.IsValid)
            {
                db.Entry(raspolaze).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(raspolaze);
        }

        [Authorize(Users = "ana@gmail.com, nina@gmail.com")]
        public ActionResult Delete(int id)
        {
            Raspolaze raspolaze = db.Raspolaze_set.Find(id);
            return View(raspolaze);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Raspolaze raspolaze = db.Raspolaze_set.Find(id);
            db.Raspolaze_set.Remove(raspolaze);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Raspolaze raspolaze = db.Raspolaze_set.Find(id);
            return View(raspolaze);

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