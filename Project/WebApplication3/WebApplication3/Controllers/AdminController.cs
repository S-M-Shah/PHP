using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;
using System.Data.Entity;

namespace WebApplication3.Controllers
{
   
    public class AdminController : Controller
    {
        Database1Entities1 db = new Database1Entities1();
        // GET: Admin
        public ActionResult Index()
        {
            if (Session != null && Session["AId"] != null)
            {
                return View();
            }
            return RedirectToAction("AdminLogin");
        }
        //Login
        public ActionResult AdminLogin()
        {
            
                return View();
           
        }
        [HttpPost]
        public ActionResult AdminLogin(User ad)
        {
            var match = db.Users.Where(x => x.users_name == ad.users_name && x.Password == ad.Password).FirstOrDefault();
            if (match == null)
            {
                ViewBag.msd = "Incorrect Username or Password";
                return View();
            }
            else
            {
                Session["AId"] = match.Id;
                Session["AName"] = match.users_name;
                return RedirectToAction("Index");

            }

        }

        public ActionResult Adminlogout()
        {
            Session.RemoveAll();
            Session.Abandon();
            return RedirectToAction("AdminLogin");
        }





    }
}