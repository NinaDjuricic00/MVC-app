using Pojekat3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pojekat3.Controllers
{
    public class TipProizvoda2Controller : Controller
    {
        private Model1 db = new Model1();
        public ActionResult Index()
        {
            return View(db.TipProizvoda_set.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include ="TipProizvoda2ID, Vrsta")] TipProizvoda  tipProizvoda)
        {
            if(ModelState.IsValid)
            {
                db.TipProizvoda_set.Add(tipProizvoda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipProizvoda);
        }
    }
}