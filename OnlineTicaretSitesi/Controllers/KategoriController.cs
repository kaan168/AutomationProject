using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicaretSitesi.Models.Siniflar;

namespace OnlineTicaretSitesi.Controllers
{
    public class KategoriController : Controller
    {
        Context db = new Context();
        public ActionResult Index()
        {
            var degerler = db.Kategoris.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(Kategori k)
        {
            db.Kategoris.Add(k);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriSil(int id)
        {
            var ktg = db.Kategoris.Find(id);
            db.Kategoris.Remove(ktg);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var ktg = db.Kategoris.Find(id);
            return View("KategoriGetir", ktg);
        }
        public ActionResult KategoriGüncelle(Kategori k)
        {
            var ktg = db.Kategoris.Find(k.KategoriID);
            ktg.KategoriAd = k.KategoriAd;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}