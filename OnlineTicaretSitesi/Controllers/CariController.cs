using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicaretSitesi.Models.Siniflar;

namespace OnlineTicaretSitesi.Controllers
{
    public class CariController : Controller
    {
        // GET: Cari
        Context db = new Context();
        public ActionResult Index()
        {
            var degerler = db.Carilers.Where(x => x.Durum == true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult CariEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CariEkle(Cariler p)
        {
            p.Durum = true;
            db.Carilers.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariSil(int id)
        {
            var cr = db.Carilers.Find(id);
            cr.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariGetir(int id)
        {
            var cr = db.Carilers.Find(id);
            return View("CariGetir", cr);
        }
        public ActionResult CariGuncelle(Cariler p)
        {
            if(!ModelState.IsValid)
            {
                return View("CariGetir");
            }
            var cr = db.Carilers.Find(p.CariID);
            cr.CariAd = p.CariAd;
            cr.CariSoyad = p.CariSoyad;
            cr.CariSehir = p.CariSehir;
            cr.CariMail = p.CariMail;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriSatis(int id)
        {
            var degerler = db.SatisHarekets.Where(x => x.Cariid == id).ToList();
            var cr = db.Carilers.Where(x => x.CariID == id).Select(y => y.CariAd + " " + y.CariSoyad).FirstOrDefault();
            ViewBag.cari = cr;
            return View(degerler);
        }
    }
}