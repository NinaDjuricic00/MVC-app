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
    public class ZemljaUvozaController : Controller
    {   
        private Model1 db = new Model1();
        public ActionResult Index()
        {
            return View(db.ZemljaUvoza_set.ToList());
        }

        [Authorize(Users = "ana@gmail.com, nina@gmail.com")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ZemljaUvozaID, Naziv")] ZemljaUvoza zemljaUvoza)
        {
            if (ModelState.IsValid)
            {
                db.ZemljaUvoza_set.Add(zemljaUvoza);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(zemljaUvoza);
        }

        [Authorize(Users = "ana@gmail.com, nina@gmail.com")]
        public ActionResult Edit(int id)
        {
            ZemljaUvoza zemljaUvoza = db.ZemljaUvoza_set.Find(id);
            return View(zemljaUvoza);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ZemljaUvozaID, Naziv")] ZemljaUvoza zemljaUvoza)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zemljaUvoza).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(zemljaUvoza);
        }

        [Authorize(Users = "ana@gmail.com, nina@gmail.com")]
        public ActionResult Delete(int id)
        {
            ZemljaUvoza zemljaUvoza = db.ZemljaUvoza_set.Find(id);
            return View(zemljaUvoza);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ZemljaUvoza zemljaUvoza = db.ZemljaUvoza_set.Find(id);
            db.ZemljaUvoza_set.Remove(zemljaUvoza);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            ZemljaUvoza zemljaUvoza = db.ZemljaUvoza_set.Find(id);
            return View(zemljaUvoza);

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