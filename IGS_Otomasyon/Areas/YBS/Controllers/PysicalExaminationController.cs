using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IGS_Otomasyon.Models;

namespace IGS_Otomasyon.Areas.YBS.Controllers
{
    public class PysicalExaminationController : Controller
    {
        //
        // GET: /YBS/PysicalExamination/
        public ActionResult Index()
        {
            List<Muayene> result;

            using (IsgEntities db = new IsgEntities())
            {
                result = db.Muayene.Include(i=>i.Personel.Kimlik).ToList();
            }
            return View(result);
        }

        public ActionResult PysicalExaminationCreate(int? id)
        {
            if (id != null)
            {
                using (var db = new IsgEntities())
                {
                    var pysicalExamination = db.Muayene.FirstOrDefault(f => f.MuayeneId == id);
                    if (pysicalExamination != null)
                    {
                        return View(pysicalExamination);
                    }
                    return RedirectToAction("Anasayfa", "Home", new { area = "YBS" });
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult PysicalExaminationCreate(int? id, Muayene muayene)
        {
            if (id != null)
            {
                using (var db = new IsgEntities())
                {
                    db.Entry(muayene).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                using (var db = new IsgEntities())
                {
                    db.Entry(muayene).State = EntityState.Added;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index", "PysicalExamination", new { area = "YBS" });
        }

        public ActionResult DeletePysicalExamination(int id)
        {
            using (var db = new IsgEntities())
            {
                var pysicalExamination = db.Muayene.FirstOrDefault(f => f.MuayeneId == id);

                db.Entry(pysicalExamination).State = EntityState.Deleted;
                db.SaveChanges();
            }
            return RedirectToAction("Index", "PysicalExamination", new { area = "YBS" });
        }
	}
}