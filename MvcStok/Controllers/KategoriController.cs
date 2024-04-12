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
            if(!ModelState.IsValid) // Doğrulanma işlemi yapılmadıysa
            {
                return View("YeniKategori"); //YeniKategori View ini bana geri döndürsün

            }
            db.TBL_KATEGORI.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult SIL(int id)
        {
            //Find = istenilen değere göre bul
            var kategori = db.TBL_KATEGORI.Find(id);
            db.TBL_KATEGORI.Remove(kategori);  
            //SaveChanges = Değişiklikleri kaydet
            db.SaveChanges();
            //RedirectToAction = İstenilene beni yönlendir(sayfa olabilir)
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.TBL_KATEGORI.Find(id);
            return View("KategoriGetir", ktgr);
        }
        public ActionResult Guncelle(TBL_KATEGORI p1)
        {
            var ktgr = db.TBL_KATEGORI.Find(p1.KATEGORIID);
            ktgr.KATEGORIAD = p1.KATEGORIAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}