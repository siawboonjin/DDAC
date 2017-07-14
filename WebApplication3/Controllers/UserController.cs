using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel lvm)
        {
            var user = new User();
            using (Model1Container context = new Model1Container())
            {
                user = context.Users.Where(a => a.username == lvm.username && a.password == lvm.password).FirstOrDefault();
            }

            if (user == null)
            {
                ModelState.AddModelError("", "Invalid username or password!");
            }
            else
            {
                //ModelState.AddModelError("", "Successful");
                Session["LogonUser"] = user;
                return RedirectToAction("Index", "Home");
                //("Index = Page", "Home = Controller")
            }
            return View();
        }
        //public ActionResult User()
        //{

        //    if (Session["LogonUser"] == null)
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }
        //}
        public ActionResult Logout()
        {

            Session["LogonUser"] = null;
            return RedirectToAction("Index", "Home");

        }

    }
}