using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicaretSitesi.Models.Siniflar;
namespace OnlineTicaretSitesi.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        Context db = new Context();
        public ActionResult Index()
        {
            var degerler = db.Personels.Include("Departman").ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult PersonelEkle()
        {

            List<SelectListItem> deger1 = (from x in db.Departmans.ToList()
                                           select new SelectListItem
                                           {
                                               
                                               Text = x.DepartmanAd,
                                               Value = x.DepartmanID.ToString()
                                           }).ToList();

            ViewBag.dgr1 = deger1;



            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(Personel p)
        {
            db.Personels.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in db.Departmans.ToList()
                                           select new SelectListItem
                                           {

                                               Text = x.DepartmanAd,
                                               Value = x.DepartmanID.ToString()
                                           }).ToList();

            ViewBag.dgr1 = deger1;


            var prs = db.Personels.Find(id);
            return View("PersonelGetir",prs);
        }
        public ActionResult PersonelGuncelle(Personel p)
        {
            var prsn = db.Personels.Find(p.PersonelID);

            prsn.PersonelAd = p.PersonelAd;
            prsn.PersonelSoyad = p.PersonelSoyad;
            prsn.PersonelGorsel = p.PersonelGorsel;
            prsn.Departmanid = p.Departmanid;
            db.SaveChanges();
            return RedirectToAction("Index");
             
        }
        public ActionResult PersonelListe()
        {
            var sorgu = db.Personels.ToList();
            return View(sorgu);
        }
        }
}