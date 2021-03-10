using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicaretSitesi.Models.Siniflar;

namespace OnlineTicaretSitesi.Controllers
{
    public class FaturaController : Controller
    {
        Context db = new Context();
        public ActionResult Index()
        {
            var liste = db.Faturalars.ToList();
            return View(liste);
        }
        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FaturaEkle(Faturalar f)
        {
            db.Faturalars.Add(f);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaGetir(int id)
        {
            var degerler = db.Faturalars.Find(id);
            return View("FaturaGetir", degerler);
        }
        public ActionResult FaturaGuncelle(Faturalar f)
        {
            var fat = db.Faturalars.Find(f.FaturaID);
            fat.FaturaSeriNo = f.FaturaSeriNo;
            fat.FaturaSıraNo = f.FaturaSıraNo;
            fat.VergiDairesi = f.VergiDairesi;
            fat.Tarih = f.Tarih;
            fat.Saat = f.Saat;
            fat.TeslimEden = f.TeslimEden;
            fat.TeslimAlan = f.TeslimAlan;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaDetay(int id)
        {
            var degerler = db.FaturaKalems.Where(x => x.Faturaid == id).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKalem()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKalem(FaturaKalem p)
        {
            db.FaturaKalems.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}