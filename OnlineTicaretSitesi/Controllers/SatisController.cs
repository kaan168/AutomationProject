using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicaretSitesi.Models.Siniflar;

namespace OnlineTicaretSitesi.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        Context db = new Context();
        public ActionResult Index()
        {
            var degerler = db.SatisHarekets.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            List<SelectListItem> deger1 = (from x in db.Uruns.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.UrunAd,
                                               Value = x.UrunID.ToString()
                                           }).ToList();

            List<SelectListItem> deger2 = (from x in db.Carilers.Where(x=>x.Durum==true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAd +" " + x.CariSoyad,
                                               Value = x.CariID.ToString()
                                           }).ToList();
            List<SelectListItem> deger3 = (from x in db.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd +" "+x.PersonelSoyad,
                                               Value = x.PersonelID.ToString()
                                           }).ToList();
            
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            return View();
        
        }
        [HttpPost]
        public ActionResult YeniSatis(SatisHareket satis)
        {
            satis.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.SatisHarekets.Add(satis);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SatisGetir(int id)
        {
            var deger = db.SatisHarekets.Find(id);

            List<SelectListItem> deger1 = (from x in db.Uruns.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.UrunAd,
                                               Value = x.UrunID.ToString()
                                           }).ToList();

            List<SelectListItem> deger2 = (from x in db.Carilers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAd + " " + x.CariSoyad,
                                               Value = x.CariID.ToString()
                                           }).ToList();
            List<SelectListItem> deger3 = (from x in db.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + " " + x.PersonelSoyad,
                                               Value = x.PersonelID.ToString()
                                           }).ToList();

            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;


            return View("SatisGetir", deger);
        }
        public ActionResult SatisGuncelle(SatisHareket p)
        {
            var deger = db.SatisHarekets.Find(p.SatisID);
            deger.Cariid = p.Cariid;
            deger.Adet = p.Adet;
            deger.Fiyat = p.Fiyat;
            deger.Personelid = p.Personelid;
            deger.Tarih = p.Tarih;
            deger.ToplamTutar = p.ToplamTutar;
            deger.Urunid = p.Urunid;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SatisDetay(int id)
        {
            var degerler = db.SatisHarekets.Where(x => x.SatisID == id).ToList();
            return View(degerler);
        }
    }
}