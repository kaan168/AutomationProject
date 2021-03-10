﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicaretSitesi.Models.Siniflar;

namespace OnlineTicaretSitesi.Controllers
{
    public class DepartmanController : Controller
    {
        // GET: Departman
        Context db = new Context();
        public ActionResult Index()
        {
            var degerler = db.Departmans.Where(x => x.Durum).ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DepartmanEkle(Departman d)
        {
            d.Durum = true;
            db.Departmans.Add(d);
            
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanSil(int id)
        {
            var dpt = db.Departmans.Find(id);
            dpt.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanGetir(int id)
        {
            var dpt = db.Departmans.Find(id);
            
            return View("DepartmanGetir", dpt);
        }

        public ActionResult DepartmanGuncelle(Departman dpr)
        {
            var dpt = db.Departmans.Find(dpr.DepartmanID);

            dpt.DepartmanAd = dpr.DepartmanAd;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanDetay(int id)
        {
            var degerler = db.Personels.Where(x => x.Departmanid == id).ToList();
            var dpt = db.Departmans.Where(x => x.DepartmanID == id).Select(y => y.DepartmanAd).FirstOrDefault();
            ViewBag.d = dpt;
            return View(degerler);
        }
        public ActionResult DepartmanPersonelSatis(int id)
        {
            var degerler = db.SatisHarekets.Where(x => x.Personelid == id).ToList();
            var per = db.Personels.Where(x => x.PersonelID == id).Select(y => y.PersonelAd +" "+ y.PersonelSoyad).FirstOrDefault();
            ViewBag.dpers = per;
            return View(degerler);
        }
    }
}