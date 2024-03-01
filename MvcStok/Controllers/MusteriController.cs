using MvcStok.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcStok.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        // db benim nesnem MvcDbStokEntities sınıfından türettiğim bir nesnem.
        // MvcDbStokEntities ise modelimi tutuyor.Modelimin içerisinde ise tablolarım var. Tablolar ulaşmak için db nesnesine
        // ihtiyaç var.

        MvcDbStokEntities db = new MvcDbStokEntities();

        //index sağ tuş yeni bir view ekliyoruz.
        public ActionResult Index()
        {

            var degerler = db.TBL_MUSTERILER.ToList();
            return View(degerler);
        }
    }
}