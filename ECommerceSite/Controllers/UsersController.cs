using System.Linq;
using System.Web.Mvc;
using ECommerceSite.Models;

namespace ECommerceSite.Controllers
{
    public class UsersController : Controller
    {
        private maocoConnEntities db = new maocoConnEntities();

        // GET: Users/Create
        public ActionResult Create()
        {
            ViewBag.Adres_Id = new SelectList(db.Adress, "Id", "City");
            return View();
        }

        [HttpPost]
        public ActionResult Create( User user)
        {
            if (ModelState.IsValid)
            {
                db.User.Add(user);
                db.SaveChanges();
                return RedirectToAction("MakePayment", "Home");
            }

            ViewBag.Adres_Id = new SelectList(db.Adress, "Id", "City", user.Adres_Id);
            return View(user);
        }

        public ActionResult Route()
        {
            return RedirectToAction("Create", "Users");
        }
    }
}
