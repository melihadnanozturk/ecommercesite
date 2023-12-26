using ECommerceSite.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Mvc;

namespace ECommerceSite.Controllers
{
    public class HomeController : Controller
    {

        private maocoConnEntities db = new maocoConnEntities();

        public ActionResult Index()
        {
            ViewModel viewModel = new ViewModel();

            viewModel.Tech_Prod_List = db.Tech_Prod.ToList();
            viewModel.Edu_Prod_List = db.Edu_Prod.ToList();
            viewModel.Text_Prod_List = db.Text_Prod.ToList();

            return View(viewModel);
        }

        public ActionResult ListTechProducts(string category)
        {
            ViewTechProdModel viewModel = new ViewTechProdModel();

            if (string.IsNullOrEmpty(category))
            {
                // Kategori parametresi yoksa veya boşsa, tüm ürünleri getir.
                viewModel.Tech_Prod_List = db.Tech_Prod.ToList();
            }
            else
            {
                // Kategori parametresi varsa, ilgili kategoriye göre filtrele.
                viewModel.Tech_Prod_List = db.Tech_Prod.Where(p => p.Tech_Category.Category == category).ToList();
            }

            return View(viewModel);
        }

        public ActionResult ListEduProducts(string category)
        {
            ViewEduProdModel viewModel = new ViewEduProdModel();

            if (string.IsNullOrEmpty(category))
            {
                // Kategori parametresi yoksa veya boşsa, tüm ürünleri getir.
                viewModel.Edu_Prods = db.Edu_Prod.ToList();
            }
            else
            {
                // Kategori parametresi varsa, ilgili kategoriye göre filtrele.
                viewModel.Edu_Prods = db.Edu_Prod.Where(p => p.Edu_Category.Category == category).ToList();
            }

            return View(viewModel);
        }

        public ActionResult ListTextProducts(string category)
        {
            ViewTextProdModel viewModel = new ViewTextProdModel();

            if (string.IsNullOrEmpty(category))
            {
                // Kategori parametresi yoksa veya boşsa, tüm ürünleri getir.
                viewModel.Text_Prods = db.Text_Prod.ToList();
            }
            else
            {
                // Kategori parametresi varsa, ilgili kategoriye göre filtrele.
                viewModel.Text_Prods = db.Text_Prod.Where(p => p.Text_Category.Category == category).ToList();
            }

            return View(viewModel);
        }

        public ActionResult AboutUs()
        {

            return View();
        }

        public ActionResult GetTechProdDetails(int? id)
        {
            if (id == null)
            {
                // Eğer id null ise, hata mesajı gösterilebilir veya başka bir sayfaya yönlendirilebilir.
                return HttpNotFound(); // veya return RedirectToAction("Index");
            }

            Tech_Prod tech_Prod = db.Tech_Prod.FirstOrDefault(p => p.Id == id);
            if (tech_Prod == null)
            {
                // Eğer ürün bulunamazsa, hata mesajı gösterilebilir veya başka bir sayfaya yönlendirilebilir.
                return HttpNotFound(); // veya return RedirectToAction("Index");
            }

            return View(tech_Prod);
        }

        public ActionResult GetEduProdDetails(int? id)
        {
            if (id == null)
            {
                // Eğer id null ise, hata mesajı gösterilebilir veya başka bir sayfaya yönlendirilebilir.
                return HttpNotFound(); // veya return RedirectToAction("Index");
            }

            Edu_Prod edu_Prod = db.Edu_Prod.FirstOrDefault(p => p.Id == id);
            if (edu_Prod == null)
            {
                // Eğer ürün bulunamazsa, hata mesajı gösterilebilir veya başka bir sayfaya yönlendirilebilir.
                return HttpNotFound(); // veya return RedirectToAction("Index");
            }

            return View(edu_Prod);
        }

        public ActionResult GetTextProdDetails(int? id)
        {
            if (id == null)
            {
                // Eğer id null ise, hata mesajı gösterilebilir veya başka bir sayfaya yönlendirilebilir.
                return HttpNotFound(); // veya return RedirectToAction("Index");
            }

            Text_Prod text_Prod = db.Text_Prod.FirstOrDefault(p => p.Id == id);
            if (text_Prod == null)
            {
                // Eğer ürün bulunamazsa, hata mesajı gösterilebilir veya başka bir sayfaya yönlendirilebilir.
                return HttpNotFound(); // veya return RedirectToAction("Index");
            }

            return View(text_Prod);
        }

        public ActionResult AddEduPordToBasket(int id)
        {
            Edu_Prod edu_Prod = db.Edu_Prod.FirstOrDefault(p => p.Id == id);
            if (edu_Prod == null)
            {
                // Eğer ürün bulunamazsa, hata mesajı gösterilebilir veya başka bir sayfaya yönlendirilebilir.
                return HttpNotFound(); // veya return RedirectToAction("Index");
            }

            var prodList = HttpContext.Session["EduProducts"] as List<Edu_Prod>;

            if (prodList == null)
            {
                prodList = new List<Edu_Prod>();
            }

            if (!prodList.Any(p => p.Id == edu_Prod.Id))
            {
                prodList.Add(edu_Prod);

                HttpContext.Session["EduProducts"] = prodList;
            }

            TempData["SuccessMessage"] = "Ürün sepete başarıyla eklendi.";


            return RedirectToAction("ListEduProducts", "Home");
        }

        public ActionResult AddTechPordToBasket(int id)
        {
            Tech_Prod tech_Prod = db.Tech_Prod.FirstOrDefault(p => p.Id == id);
            if (tech_Prod == null)
            {
                // Eğer ürün bulunamazsa, hata mesajı gösterilebilir veya başka bir sayfaya yönlendirilebilir.
                return HttpNotFound(); // veya return RedirectToAction("Index");
            }

            var prodList = HttpContext.Session["TechProducts"] as List<Tech_Prod>;

            if (prodList == null)
            {
                prodList = new List<Tech_Prod>();
            }

            if (!prodList.Any(p => p.Id == tech_Prod.Id))
            {
                prodList.Add(tech_Prod);

                HttpContext.Session["TechProducts"] = prodList;
            }

            TempData["SuccessMessage"] = "Ürün sepete başarıyla eklendi.";


            return RedirectToAction("ListTechProducts", "Home");
        }

        public ActionResult AddTextPordToBasket(int id)
        {
            Text_Prod text_Prod = db.Text_Prod.FirstOrDefault(p => p.Id == id);
            if (text_Prod == null)
            {
                return HttpNotFound();
            }

            var prodList = HttpContext.Session["TextProducts"] as List<Text_Prod>;

            if (prodList == null)
            {
                prodList = new List<Text_Prod>();
            }

            if (!prodList.Any(p => p.Id == text_Prod.Id))
            {
                prodList.Add(text_Prod);

                HttpContext.Session["TextProducts"] = prodList;
            }

            TempData["SuccessMessage"] = "Ürün sepete başarıyla eklendi.";


            return RedirectToAction("ListTextProducts", "Home");
        }

        public ActionResult ShowBasket()
        {
            var techProds = HttpContext.Session["TechProducts"] as List<Tech_Prod> ?? new List<Tech_Prod>();
            var eduProds = HttpContext.Session["EduProducts"] as List<Edu_Prod> ?? new List<Edu_Prod>();
            var textProds = HttpContext.Session["TextProducts"] as List<Text_Prod> ?? new List<Text_Prod>();

            ViewBag.TechProducts = techProds;
            ViewBag.EduProducts = eduProds;
            ViewBag.TextProducts = textProds;

            BasketViewModel basketView = new BasketViewModel();
            basketView.EduProducts.AddRange(eduProds);
            basketView.TextProducts.AddRange(textProds);
            basketView.TechProducts.AddRange(techProds);

            return View(basketView);
        }

        public ActionResult MakePayment()
        {

            var technologyProducts = HttpContext.Session["TechProducts"] as List<ECommerceSite.Models.Tech_Prod>;
            var educationProducts = HttpContext.Session["EduProducts"] as List<ECommerceSite.Models.Edu_Prod>;
            var textileProducts = HttpContext.Session["TextProducts"] as List<ECommerceSite.Models.Text_Prod>;

            Basket basket = new Basket();
            basket.Total_Price = Convert.ToDecimal(HttpContext.Session["totalAmount"]);
            basket.User_Id = 14;
            basket.Payment_Method = "CREDIT_CARD";
            basket.Created_At = DateTime.Now;
            
            db.Basket.Add(basket);
            db.SaveChanges();

            if (technologyProducts != null)
            {
                foreach (var product in technologyProducts)
                {
                    Tech_Saled_Prod tech_Saled_Prod = new Tech_Saled_Prod();
                    tech_Saled_Prod.Tech_Prod_Id = product.Id;
                    tech_Saled_Prod.Basket_Id = basket.Id;
                    tech_Saled_Prod.Saled_Number = 1;

                    db.Tech_Saled_Prod.Add(tech_Saled_Prod);
                }
            }

            if (educationProducts != null)
            {
                foreach (var product in educationProducts)
                {
                    Edu_Saled_Prod edu_Saled_Prod= new Edu_Saled_Prod();
                    edu_Saled_Prod.Edu_Prod_Id= product.Id;
                    edu_Saled_Prod.Basket_Id = basket.Id;
                    edu_Saled_Prod.Saled_Number = 1;

                    db.Edu_Saled_Prod.Add(edu_Saled_Prod);
                }
            }

            if (textileProducts != null)
            {
                foreach (var product in textileProducts)
                {
                    Text_Saled_Prod text_Saled_Prod= new Text_Saled_Prod();
                    text_Saled_Prod.Prod_Id = product.Id;
                    text_Saled_Prod.Basket_Id = basket.Id;
                    text_Saled_Prod.Saled_Number = 1;

                    db.Text_Saled_Prod.Add(text_Saled_Prod);
                }
            }

            db.SaveChanges();


            var isLogin = HttpContext.Session["isLogin"] as bool?;

            if (isLogin != true)
            {
                return RedirectToAction("LoginUserForPayment", "User");
            }

            return View();

        }

        public ActionResult CompleteMakePayment()
        {

            return View();

        }

    }
}