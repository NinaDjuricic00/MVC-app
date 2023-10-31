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
    public class DrogerijaController : Controller
    {
        private Model1 db = new Model1();
        public ActionResult Index(string pretrazi, int page=1)
        {
            var model = db.Drogerija_set
                        .OrderBy(s => s.Naziv)
                        .Where(s => pretrazi == null || s.PIB.StartsWith(pretrazi))
                        .ToList()
                        .ToPagedList(page, 5);

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }
        [Authorize(Users = "ana@gmail.com, nina@gmail.com")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DrogerijaID, Naziv, Adresa,PIB")] Drogerija drogerija)
        {
            if (ModelState.IsValid)
            {
                db.Drogerija_set.Add(drogerija);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(drogerija);
        }
        [Authorize(Users = "ana@gmail.com, nina@gmail.com")]
        public ActionResult Edit(int id)
        {
            Drogerija drogerija = db.Drogerija_set.Find(id);
            return View(drogerija);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DrogerijaID, Naziv, Adresa, PIB")] Drogerija drogerija)
        {
            if(ModelState.IsValid)
            {
                db.Entry(drogerija).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(drogerija);
        }

        [Authorize(Users ="ana@gmail.com, nina@gmail.com")]
        public ActionResult Delete(int id)
        {
            Drogerija drogerija = db.Drogerija_set.Find(id);
            return View(drogerija);
        }
        
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Drogerija drogerija = db.Drogerija_set.Find(id);
            db.Drogerija_set.Remove(drogerija);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            Drogerija drogerija = db.Drogerija_set.Find(id);
            return View(drogerija);

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