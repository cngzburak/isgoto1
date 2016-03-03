using IGS_Otomasyon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;



namespace IGS_Otomasyon.Areas.YBS.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Ajanda()
        {
            return View();
        }
        public ActionResult Anasayfa()
        {
            return View();
        }


        public ActionResult Muayene()
        {
            List<Muayene> result = new List<Muayene>();

            using (IsgEntities db = new IsgEntities())
            {
                result = db.Muayene.ToList();
            }
            return View(result);
        }






    }
}