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
        //URUN Ekleme işlemi
        //butona basana kadar ekleme işlemi gerçekleştirme yapmamız gerekir.Yoksa her sayfa açıldığında actionresult null veri 
        //ekler. Bunun için HttpGet ve HttpPost kullanılır.

        //LINQ komutlarını incele
        //Dropdowna çevirme işlemi
        //Dropdownlist ile DB den veri çekme
        //SelectListItem liste tipi kullanım
        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> degerler = (from i in db.TBL_KATEGORI.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORIID.ToString()
                                             }
                                             ).ToList();
            ViewBag.dgr = degerler; // ViewBag controller tarafındaki ifadeyi diğer sayfaya taşıyacak. ViewBag herhangi bir nesne
                                    // türeterek  diğer sayfada bu nesneyi kullanacağız.
            return View();
        }

        [HttpPost]
        public ActionResult UrunEkle(TBL_URUNLER p1)
        {
            //LINQ sorgusu
            var ktg = db.TBL_KATEGORI.Where(m => m.KATEGORIID == p1.TBL_KATEGORI.KATEGORIID).FirstOrDefault();
            p1.TBL_KATEGORI = ktg;
            db.TBL_URUNLER.Add(p1);
            db.SaveChanges();
            // RedirectToAction kaydetme işlemi gerçekleştikten sonra index sayfasına döndürür.
            return RedirectToAction("Index");
        }
        public ActionResult SIL(int id)
        {
            var urun = db.TBL_URUNLER.Find(id);
            //Remove = istenileni kaldır
            db.TBL_URUNLER.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            var urun = db.TBL_URUNLER.Find(id);

            List<SelectListItem> degerler = (from i in db.TBL_KATEGORI.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORIID.ToString()
                                             }
                                            ).ToList();
            ViewBag.dgr = degerler; // ViewBag controller tarafındaki ifadeyi diğer sayfaya taşıyacak. ViewBag herhangi bir nesne
                                    // türeterek  diğer sayfada bu nesneyi kullanacağız.

            return View("UrunGetir", urun);
        }
    }
}