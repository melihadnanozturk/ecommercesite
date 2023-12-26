using ECommerceSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerceSite.Controllers
{
    public class AdminController : Controller
    {
        private maocoConnEntities db = new maocoConnEntities();
        
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User user) {

                bool isValidUser = db.User.Any(u => u.UserName == user.UserName && u.Password == user.Password);

                if (isValidUser)
                {
                Session.Add("isLogin",true);
                     //Doğrulama başarılı ise, Admin Paneline yönlendir
                    return RedirectToAction("AdminPanel", "Admin");
                }
                else
                {
                     //Doğrulama başarısız ise, hata mesajı ile tekrar login sayfasını göster
                   ViewBag.ErrorMessage = "Girilen bilgiler hatalıdır. Lütfen tekrar deneyin.";
                  return View(ViewBag);
                }
        }

        public ActionResult AdminPanel()
        {

            var adminIsLogin = Session["isLogin"];

            if (adminIsLogin == null) {

                return RedirectToAction("Index", "Admin");

            }
            return View();
        }
    }
}