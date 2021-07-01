using OnlineTicaretSitesi.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineTicaretSitesi.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        Context db = new Context();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult Partial1()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Partial1(Cariler cari)
        {
            db.Carilers.Add(cari);
            db.SaveChanges();
            
            return PartialView();
        }
        [HttpGet]
        public ActionResult CarilLogin1()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CariLogin1(Cariler cari)
        {
            var bilgiler = db.Carilers.FirstOrDefault(x => x.CariMail == cari.CariMail &&
                x.CariSifre == cari.CariSifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.CariMail, false);
                Session["CariMail"] = bilgiler.CariMail.ToString();
                return RedirectToAction("Index", "CariPanel");
            }
            else
            {
                return RedirectToAction("Index","Login");
            }
        }
         [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        public ActionResult AdminLogin(Admin admin)
        {
            var bilgiler = db.Admins.FirstOrDefault(x => x.KullaniciAd == admin.KullaniciAd &&
              x.Sifre == admin.Sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KullaniciAd, false);
                Session["KullaniciAd"] = bilgiler.KullaniciAd.ToString();
                return RedirectToAction("Index", "Kategori");
            }
            else
            {
                return RedirectToAction("Index","Login");
            }
        }
    }
}