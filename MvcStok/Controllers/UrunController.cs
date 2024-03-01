using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        // db benim nesnem MvcDbStokEntities sınıfından türettiğim bir nesnem.
        // MvcDbStokEntities ise modelimi tutuyor.Modelimin içerisinde ise tablolarım var. Tablolar ulaşmak için db nesnesine
        // ihtiyaç var.
        MvcDbStokEntities db = new MvcDbStokEntities();

        //index sağ tuş yeni bir view ekliyoruz.
        public ActionResult Index()
        {
            var degerler = db.TBL_URUNLER.ToList();
            return View(degerler);
        }
    }
}