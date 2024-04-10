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
        //musteri Ekleme işlemi
        //butona basana kadar ekleme işlemi gerçekleştirme yapmamız gerekir.Yoksa her sayfa açıldığında actionresult null veri 
        //ekler. Bunun için HttpGet ve HttpPost kullanılır.
        [HttpGet]
        public ActionResult YeniMusteri() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMusteri(TBL_MUSTERILER p1)
        {
            db.TBL_MUSTERILER.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult SIL(int id)
        {
            var musteri = db.TBL_MUSTERILER.Find(id);
            db.TBL_MUSTERILER.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriGetir(int id)
        {
            var mus = db.TBL_MUSTERILER.Find(id);
            return View("MusteriGetir", mus);
        }
        public ActionResult Guncelle(TBL_MUSTERILER p1)
        {
            var musteri = db.TBL_MUSTERILER.Find(p1.MUSTERIID);
            musteri.MUSTERIAD = p1.MUSTERIAD;
            musteri.MUSTERISOYAD = p1.MUSTERISOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}