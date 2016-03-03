using IGS_Otomasyon.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq;

namespace IGS_Otomasyon.Areas.YBS.Controllers
{
    public class PersonelController : Controller
    {
        //
        // GET: /YBS/Personel/
        public ActionResult Index()
        {
            List<Personel> result;

            using (IsgEntities db = new IsgEntities())
            {
                result = db.Personel.Include(i => i.Kimlik).Include(i => i.Iletisim).Include(i => i.Ogrenim).Include(i => i.Sabika).Include(i => i.Saglik).Where(w => !w.Arsivlendi).ToList();
            }
            return View(result);
        }

        public ActionResult PersonelCreate(int? id)
        {
            if (id != null)
            {
                using (var db = new IsgEntities())
                {
                    var personel = db.Personel.Include(i => i.Kimlik).Include(i => i.Iletisim).Include(i => i.Ogrenim).Include(i => i.Sabika).Include(i => i.Saglik).FirstOrDefault(f => f.PersonelId == id);
                    if (personel != null)
                    {
                        return View(personel);
                    }
                    return RedirectToAction("Index", "Personel", new { area = "YBS" });
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult PersonelCreate(int? id, Personel personel)
        {
            //personel = new Personel { Kisi = new Kisi { Kimlik = new Kimlik() } };
            if (id != null)
            {
                personel.UpdateTime = DateTime.Now;
                using (var db = new IsgEntities())
                {
                    personel.UpdateTime = DateTime.Now;
                    db.Entry(personel.Iletisim).State = EntityState.Modified;
                    db.Entry(personel.Kimlik).State = EntityState.Modified;
                    db.Entry(personel.Ogrenim).State = EntityState.Modified;
                    db.Entry(personel.Sabika).State = EntityState.Modified;
                    db.Entry(personel.Saglik).State = EntityState.Modified;
                    db.Entry(personel).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                personel.CreateTime = DateTime.Now;
                personel.UpdateTime = DateTime.Now;
                using (var db = new IsgEntities())
                {
                    db.Entry(personel).State = EntityState.Added;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index", "Personel", new { area = "YBS" });
        }

        public ActionResult DeletePersonel(int id)
        {
            using (var db = new IsgEntities())
            {
                var personel = db.Personel.Include(i => i.Kimlik).Include(i => i.Iletisim).Include(i => i.Ogrenim).Include(i => i.Sabika).Include(i => i.Saglik).FirstOrDefault(f => f.PersonelId == id);

                if (personel != null)
                {
                    db.Entry(personel.Iletisim).State = EntityState.Deleted;
                    db.Entry(personel.Kimlik).State = EntityState.Deleted;
                    db.Entry(personel.Ogrenim).State = EntityState.Deleted;
                    db.Entry(personel.Sabika).State = EntityState.Deleted;
                    db.Entry(personel.Saglik).State = EntityState.Deleted;
                    db.Entry(personel).State = EntityState.Deleted;
                }
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Personel", new { area = "YBS" });
        }
        public ActionResult ArchievePersonel(int id)
        {
            using (var db = new IsgEntities())
            {
                var personel = db.Personel.Include(i => i.Kimlik).Include(i => i.Iletisim).Include(i => i.Ogrenim).Include(i => i.Sabika).Include(i => i.Saglik).FirstOrDefault(f => f.PersonelId == id);

                if (personel != null) personel.Arsivlendi = true;
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Personel", new { area = "YBS" });
        }

    }
}