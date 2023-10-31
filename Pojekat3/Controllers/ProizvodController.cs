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
    public class ProizvodController : Controller
    {
        private Model1 db = new Model1();
        public ActionResult Index(string pretrag, int page = 1)
        {

            var model = db.Proizvod_set
                       .Where(s => pretrag == null || s.NazivProizvoda.Contains(pretrag) || s.TipProizvoda.Vrsta.StartsWith(pretrag))
                       .OrderBy(s => s.NazivProizvoda)
                       .ToList()
                       .ToPagedList(page, 5);


            return View(model);

        }

        [Authorize(Users = "ana@gmail.com, nina@gmail.com")]
        public ActionResult Create()
        {
            ViewBag.TipProizvodaID = new SelectList(db.TipProizvoda_set, "TipProizvodaID", "Vrsta");
            ViewBag.ZemljaUvozaID = new SelectList(db.ZemljaUvoza_set, "ZemljaUvozaID", "Naziv");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProizvodID,NabavnaCenaProizvoda,SifraProizvoda,OpisProizvoda, ProdajnaCenaProizvoda, NazivProizvoda, CenaProizvoda, TipProizvodaID, ZemljaUvozaID")] Proizvod proizvod)
        {
            if (ModelState.IsValid)
            {
                db.Proizvod_set.Add(proizvod);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TipProizvodaID = new SelectList(db.TipProizvoda_set, "TipProizvodaID", "Vrsta", proizvod.TipProizvodaID);
            ViewBag.ZemljaUvozaID = new SelectList(db.ZemljaUvoza_set, "ZemljaUvozaID", "Naziv", proizvod.ZemljaUvozaID);

            return View(proizvod);
        }

        [Authorize(Users = "ana@gmail.com, nina@gmail.com")]
        public ActionResult Edit(int id)
        {
            Proizvod proizvod = db.Proizvod_set.Find(id);

            ViewBag.ZemljaUvozaID = new SelectList(db.ZemljaUvoza_set, "ZemljaUvozaID", "Naziv", proizvod.ZemljaUvozaID);
            ViewBag.TipProizvodaID = new SelectList(db.TipProizvoda_set, "TipProizvodaID", "Vrsta", proizvod.TipProizvodaID);

            return View(proizvod);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProizvodID,NabavnaCenaProizvoda,SifraProizvoda,OpisProizvoda, ProdajnaCenaProizvoda, NazivProizvoda, CenaProizvoda, TipProizvodaID, ZemljaUvozaID")] Proizvod proizvod)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proizvod).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(proizvod);
        }

        [Authorize(Users = "ana@gmail.com, nina@gmail.com")]
        public ActionResult Delete(int id)
        {
            Proizvod proizvod = db.Proizvod_set.Find(id);
            return View(proizvod);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Proizvod proizvod= db.Proizvod_set.Find(id);
            db.Proizvod_set.Remove(proizvod);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            Proizvod proizvod= db.Proizvod_set.Find(id);
            return View(proizvod);

        }

        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}