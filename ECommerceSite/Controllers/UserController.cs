using ECommerceSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerceSite.Controllers
{
    public class UserController : Controller
    {
        private maocoConnEntities db = new maocoConnEntities();

        public ActionResult LoginUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginUser(User user)
        {
            bool isValidUser = db.User.Any(u => u.UserName == user.UserName && u.Password == user.Password);

            if (isValidUser)
            {
                //Doğrulama başarılı ise, Admin Paneline yönlendir
                //return RedirectToAction("AdminPanel", "Admin");
                Session.Add("isLogin", true);
                //Doğrulama başarılı ise, Admin Paneline yönlendir
                return RedirectToAction("Index", "Home");
            }
            else
            {
                //Doğrulama başarısız ise, hata mesajı ile tekrar login sayfasını göster
                ViewBag.ErrorMessage = "Girilen bilgiler hatalıdır. Lütfen tekrar deneyin.";
                return View(ViewBag);
            }
        }

        public ActionResult LoginUserForPayment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginUserForPayment(User user)
        {
            bool isValidUser = db.User.Any(u => u.UserName == user.UserName && u.Password == user.Password);

            if (isValidUser)
            {
                Session.Add("isLogin", true);
                return RedirectToAction("makePayment", "Home");
            }
            else
            {
                //Doğrulama başarısız ise, hata mesajı ile tekrar login sayfasını göster
                ViewBag.ErrorMessage = "Girilen bilgiler hatalıdır. Lütfen tekrar deneyin.";
                return View(ViewBag);
            }
        }

        public ActionResult SignInUser()
        {
            return View();
        }

        //public ActionResult SignInUser()
        //{
        //    return View();
        //}
    }
}