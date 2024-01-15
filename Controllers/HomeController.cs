using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using e_commerce.Models;

namespace e_commerce.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Indexuser()
        {
            return View();
        }


        public ActionResult Indexadmin()
        {
            return View();
        }

        Model1 db = new Model1();
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(M_Admin a)
        {
            int r = db.M_Admin.Where(x => x.Admin_Email == a.Admin_Email && x.Admin_Password == a.Admin_Password).Count();

            if (r == 1)
            {
                return RedirectToAction("Indexadmin", "Home");
            }
            else
            {
                ViewBag.Message = "Invalid credentials";
                return View();
            }


        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult shop(int? id)
        {
            shopmodel s = new shopmodel();
            s.cat = db.M_Category.ToList();
            if (id == null)
                s.prod = db.M_Product.ToList();
            else
                s.prod = db.M_Product.Where(p => p.Category_FId == id).ToList();
            return View(s);
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}