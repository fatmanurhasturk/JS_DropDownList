using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _17Mayis.Models;

namespace _17Mayis.Controllers
{
    public class HomeController : Controller
    {
        NorthwindEntities db = new NorthwindEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View(db.iller.ToList());
        }

        [HttpPost]
        public JsonResult ilceleriGetir(int ilid)
        {
            var ilceler = db.ilceler.Where(ilce => ilce.sehir == ilid).Select(ilce => new { id = ilce.id, Ad = ilce.ilce });

            //veya

            //var ilceler2 = from ilce in db.ilceler where ilce.sehir == ilid select new { ilce.id, ilce.sehir };

            return Json(ilceler.ToList());
        }
    }
}