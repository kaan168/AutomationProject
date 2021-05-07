using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicaretSitesi.Models.Siniflar;

namespace OnlineTicaretSitesi.Controllers
{
    public class GaleriController : Controller
    {
        // GET: Galeri
        Context db = new Context();
        public ActionResult Index()
        {
            var degerler = db.Uruns.ToList();
            return View(degerler);
        }
    }
}