using IGS_Otomasyon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace IGS_Otomasyon.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string userName,string password)
        {
            using (var db = new IsgEntities())
            {
               var kullanici= db.Kullanici.FirstOrDefault(f=>f.TcNo == userName && f.Sifre == password);
                if(kullanici!=null){
                    Session["KullaniciId"]=kullanici.KullaniciId;
                    Session["TcNo"] = kullanici.TcNo;
                    Session["TamAd"] = kullanici.Isim + " " + kullanici.SoyIsim;
                    return RedirectToAction("Ajanda", "Home", new { area = "YBS" });
                }
                else
                {
                    TempData["State"] = "Error";
                    TempData["Message"] = "Kullanıcı adı veya şifre yanlış";
                    return View();
                }
            }
        }
	}
}