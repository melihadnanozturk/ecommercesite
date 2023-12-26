using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ECommerceSite.Models;

namespace ECommerceSite.Controllers
{
    public class Edu_ProdController : Controller
    {
        private maocoConnEntities db = new maocoConnEntities();

        // GET: Edu_Prod
        public ActionResult Index()
        {
            var adminIsLogin = Session["isLogin"];

            if (adminIsLogin == null)
            {

                return RedirectToAction("Index", "Admin");

            }

            var edu_Prod = db.Edu_Prod.Include(e => e.Edu_Category);
            return View(edu_Prod.ToList());
        }

        // GET: Edu_Prod/Details/5
        public ActionResult Details(int? id)
        {
            var adminIsLogin = Session["isLogin"];

            if (adminIsLogin == null)
            {

                return RedirectToAction("Index", "Admin");

            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Edu_Prod edu_Prod = db.Edu_Prod.Find(id);
            if (edu_Prod == null)
            {
                return HttpNotFound();
            }
            return View(edu_Prod);
        }

        // GET: Edu_Prod/Create
        public ActionResult Create()
        {
            var adminIsLogin = Session["isLogin"];

            if (adminIsLogin == null)
            {

                return RedirectToAction("Index", "Admin");

            }

            ViewBag.Category_Id = new SelectList(db.Edu_Category, "Id", "Category");
            return View();
        }

        // POST: Edu_Prod/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create( Edu_Prod edu_Prod)
        {
            var adminIsLogin = Session["isLogin"];

            if (adminIsLogin == null)
            {

                return RedirectToAction("Index", "Admin");

            }

            if (ModelState.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    string fileName = Path.GetFileName(Request.Files[0].FileName);
                    string uzanti = Path.GetExtension(Request.Files[0].FileName);
                    string path = "~/Images/Edu"+fileName+uzanti;
                    Request.Files[0].SaveAs(Server.MapPath(path));
                    edu_Prod.Image = "/Images/Edu" + fileName + uzanti;
                }

                db.Edu_Prod.Add(edu_Prod);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Category_Id = new SelectList(db.Edu_Category, "Id", "Category", edu_Prod.Category_Id);
            return View(edu_Prod);
        }

        // GET: Edu_Prod/Edit/5
        public ActionResult Edit(int? id)
        {
            var adminIsLogin = Session["isLogin"];

            if (adminIsLogin == null)
            {

                return RedirectToAction("Index", "Admin");

            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Edu_Prod edu_Prod = db.Edu_Prod.Find(id);
            if (edu_Prod == null)
            {
                return HttpNotFound();
            }
            ViewBag.Category_Id = new SelectList(db.Edu_Category, "Id", "Category", edu_Prod.Category_Id);
            return View(edu_Prod);
        }

        // POST: Edu_Prod/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit(Edu_Prod edu_Prod)
        {
            var adminIsLogin = Session["isLogin"];

            if (adminIsLogin == null)
            {

                return RedirectToAction("Index", "Admin");

            }

            if (ModelState.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    string fileName = Path.GetFileName(Request.Files[0].FileName);
                    string uzanti = Path.GetExtension(Request.Files[0].FileName);
                    string path = "~/Images/Edu" + fileName + uzanti;
                    Request.Files[0].SaveAs(Server.MapPath(path));
                    edu_Prod.Image = "/Images/Edu" + fileName + uzanti;
                }

                db.Entry(edu_Prod).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Category_Id = new SelectList(db.Edu_Category, "Id", "Category", edu_Prod.Category_Id);
            return View(edu_Prod);
        }

        // GET: Edu_Prod/Delete/5
        public ActionResult Delete(int? id)
        {
            var adminIsLogin = Session["isLogin"];

            if (adminIsLogin == null)
            {

                return RedirectToAction("Index", "Admin");

            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Edu_Prod edu_Prod = db.Edu_Prod.Find(id);
            if (edu_Prod == null)
            {
                return HttpNotFound();
            }
            return View(edu_Prod);
        }

        // POST: Edu_Prod/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var adminIsLogin = Session["isLogin"];

            if (adminIsLogin == null)
            {

                return RedirectToAction("Index", "Admin");

            }

            Edu_Prod edu_Prod = db.Edu_Prod.Find(id);
            db.Edu_Prod.Remove(edu_Prod);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
