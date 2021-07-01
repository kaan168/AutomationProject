using OnlineTicaretSitesi.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicaretSitesi.Controllers
{
    public class CariPanelController : Controller
    {
        // GET: CariPanel
        Context db = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["CariMail"];
            var degerler = db.Carilers.FirstOrDefault(x => x.CariMail == mail);

            ViewBag.m = mail;

            return View(degerler);
        }
        public ActionResult Siparislerim()
        {
            var mail = (string)Session["CariMail"];
            var id = db.Carilers.Where(x => x.CariMail == mail.ToString()).Select(
                y => y.CariID).FirstOrDefault();
            var degerler = db.SatisHarekets.Where(x => x.Cariid == id).ToList();
            return View(degerler);
        }

    }
}