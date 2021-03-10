using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicaretSitesi.Models.Siniflar;

namespace OnlineTicaretSitesi.Controllers
{
    public class ÜrünController : Controller
    {
        Context db = new Context();
        public ActionResult Index()
        {
            var degerler = db.Uruns.Where(x => x.Durum == true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult ÜrünEkle()
        {
            List<SelectListItem> deger1 = (from x in db.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriID.ToString()
                                           }).ToList();

            ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult ÜrünEkle(Urun u)
        {
            db.Uruns.Add(u);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunSil(int id)
        {
            var urn = db.Uruns.Find(id);
            urn.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {
            

            List<SelectListItem> deger1 = (from x in db.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriID.ToString()
                                           }).ToList();

            ViewBag.dgr1 = deger1;
            var urundeger = db.Uruns.Find(id);
            return View("UrunGetir", urundeger);
        }
      
        public ActionResult UrunGuncelle(Urun urun)
        {
            var urn = db.Uruns.Find(urun.UrunID);
            
            urn.AlisFiyat = urun.AlisFiyat;
            urn.Durum = urun.Durum;
            urn.Kategoriid = urun.Kategoriid;
            urn.Marka = urun.Marka;
            urn.SatisFiyat = urun.SatisFiyat;
            urn.Stok = urun.Stok;
            urn.UrunAd = urun.UrunAd;
            urn.UrunGorsel = urun.UrunGorsel;
            
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult UrunListesi()
        {
            var degerler = db.Uruns.ToList();
            return View(degerler);
        }
    }
}