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
    public class Tech_ProdController : Controller
    {
        private maocoConnEntities db = new maocoConnEntities();

        // GET: Tech_Prod
        public ActionResult Index()
        {
            var adminIsLogin = Session["isLogin"];

            if (adminIsLogin == null)
            {

                return RedirectToAction("Index", "Admin");

            }

            var tech_Prod = db.Tech_Prod.Include(t => t.Tech_Category);
            return View(tech_Prod.ToList());
        }

        // GET: Tech_Prod/Details/5
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
            Tech_Prod tech_Prod = db.Tech_Prod.Find(id);
            if (tech_Prod == null)
            {
                return HttpNotFound();
            }
            return View(tech_Prod);
        }

        // GET: Tech_Prod/Create
        public ActionResult Create()
        {
            var adminIsLogin = Session["isLogin"];

            if (adminIsLogin == null)
            {

                return RedirectToAction("Index", "Admin");

            }

            ViewBag.Category_Id = new SelectList(db.Tech_Category, "Id", "Category");
            return View();
        }

        // POST: Tech_Prod/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tech_Prod tech_Prod)
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
                    string path = "~/Images/Tech" + fileName + uzanti;
                    Request.Files[0].SaveAs(Server.MapPath(path));
                    tech_Prod.Image = "/Images/Tech" + fileName + uzanti;
                }

                db.Tech_Prod.Add(tech_Prod);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Category_Id = new SelectList(db.Tech_Category, "Id", "Category", tech_Prod.Category_Id);
            return View(tech_Prod);
        }

        // GET: Tech_Prod/Edit/5
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
            Tech_Prod tech_Prod = db.Tech_Prod.Find(id);
            if (tech_Prod == null)
            {
                return HttpNotFound();
            }
            ViewBag.Category_Id = new SelectList(db.Tech_Category, "Id", "Category", tech_Prod.Category_Id);
            return View(tech_Prod);
        }

        // POST: Tech_Prod/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit( Tech_Prod tech_Prod)
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
                    string path = "~/Images/Tech" + fileName + uzanti;
                    Request.Files[0].SaveAs(Server.MapPath(path));
                    tech_Prod.Image = "/Images/Tech" + fileName + uzanti;
                }

                db.Entry(tech_Prod).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Category_Id = new SelectList(db.Tech_Category, "Id", "Category", tech_Prod.Category_Id);
            return View(tech_Prod);
        }

        // GET: Tech_Prod/Delete/5
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
            Tech_Prod tech_Prod = db.Tech_Prod.Find(id);
            if (tech_Prod == null)
            {
                return HttpNotFound();
            }
            return View(tech_Prod);
        }

        // POST: Tech_Prod/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var adminIsLogin = Session["isLogin"];

            if (adminIsLogin == null)
            {

                return RedirectToAction("Index", "Admin");

            }

            Tech_Prod tech_Prod = db.Tech_Prod.Find(id);
            db.Tech_Prod.Remove(tech_Prod);
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
