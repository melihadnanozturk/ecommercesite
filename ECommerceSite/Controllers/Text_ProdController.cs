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
    public class Text_ProdController : Controller
    {
        private maocoConnEntities db = new maocoConnEntities();

        // GET: Text_Prod
        public ActionResult Index()
        {
            var adminIsLogin = Session["isLogin"];

            if (adminIsLogin == null)
            {

                return RedirectToAction("Index", "Admin");

            }

            var text_Prod = db.Text_Prod.Include(t => t.Text_Category);
            return View(text_Prod.ToList());
        }

        // GET: Text_Prod/Details/5
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
            Text_Prod text_Prod = db.Text_Prod.Find(id);
            if (text_Prod == null)
            {
                return HttpNotFound();
            }
            return View(text_Prod);
        }

        // GET: Text_Prod/Create
        public ActionResult Create()
        {
            var adminIsLogin = Session["isLogin"];

            if (adminIsLogin == null)
            {

                return RedirectToAction("Index", "Admin");

            }

            ViewBag.Category_Id = new SelectList(db.Text_Category, "Id", "Category");
            return View();
        }

        // POST: Text_Prod/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Text_Prod text_Prod)
        {
            var adminIsLogin = Session["isLogin"];

            if (adminIsLogin == null)
            {

                return RedirectToAction("Index", "Admin");

            }

            var request = Request.Files;

            if (ModelState.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    string fileName = Path.GetFileName(Request.Files[0].FileName);
                    string uzanti = Path.GetExtension(Request.Files[0].FileName);
                    string path = "~/Images/Text" + fileName + uzanti;
                    Request.Files[0].SaveAs(Server.MapPath(path));
                    text_Prod.Image = "/Images/Text" + fileName + uzanti;
                }

                db.Text_Prod.Add(text_Prod);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Category_Id = new SelectList(db.Text_Category, "Id", "Category", text_Prod.Category_Id);
            return View(text_Prod);
        }

        // GET: Text_Prod/Edit/5
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
            Text_Prod text_Prod = db.Text_Prod.Find(id);
            if (text_Prod == null)
            {
                return HttpNotFound();
            }
            ViewBag.Category_Id = new SelectList(db.Text_Category, "Id", "Category", text_Prod.Category_Id);
            return View(text_Prod);
        }

        // POST: Text_Prod/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit( Text_Prod text_Prod)
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
                    string path = "~/Images/Text" + fileName + uzanti;
                    Request.Files[0].SaveAs(Server.MapPath(path));
                    text_Prod.Image = "/Images/Text" + fileName + uzanti;
                }

                db.Entry(text_Prod).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Category_Id = new SelectList(db.Text_Category, "Id", "Category", text_Prod.Category_Id);
            return View(text_Prod);
        }

        // GET: Text_Prod/Delete/5
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
            Text_Prod text_Prod = db.Text_Prod.Find(id);
            if (text_Prod == null)
            {
                return HttpNotFound();
            }
            return View(text_Prod);
        }

        // POST: Text_Prod/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var adminIsLogin = Session["isLogin"];

            if (adminIsLogin == null)
            {

                return RedirectToAction("Index", "Admin");

            }

            Text_Prod text_Prod = db.Text_Prod.Find(id);
            db.Text_Prod.Remove(text_Prod);
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
