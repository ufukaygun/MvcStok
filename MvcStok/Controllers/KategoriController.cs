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

        //KAtegori Ekleme işlemi
        //butona basana kadar ekleme işlemi gerçekleştirme yapmamız gerekir.Yoksa her sayfa açıldığında actionresult null veri 
        //ekler. Bunun için HttpGet ve HttpPost kullanılır.

        [HttpGet]//Hergangibir işlem yapılmazsa sayfayı döndür bana veri yükleme.
        public ActionResult YeniKategori() 
        {
            return View();
        }

        [HttpPost] //kaydet butonuna basıldığı zaman buradaki işlemi gerçekleştir.
        public ActionResult YeniKategori(TBL_KATEGORI p1) 
        {
            db.TBL_KATEGORI.Add(p1);
            db.SaveChanges();
            return View();
        }
        
    }
}