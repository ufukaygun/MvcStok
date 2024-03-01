using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        // db benim nesnem MvcDbStokEntities sınıfından türettiğim bir nesnem.
        // MvcDbStokEntities ise modelimi tutuyor.Modelimin içerisinde ise tablolarım var. Tablolar ulaşmak için db nesnesine
        // ihtiyaç var.
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            // ToList ile değerlerimi listemiş oldum.
            var degerler = db.TBL_KATEGORI.ToList();
            return View(degerler);
        }
    }
}