using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;
using System.Data.Entity;
namespace WebApplication3.Controllers
{
    public class USER1Controller : Controller
    {

        Database1Entities1 bs = new Database1Entities1();
        // GET: USER1
        public ActionResult Index()
        {
          var c=  bs.Users.Include(r => r.Role);
            
                return View("USER1", c.ToList());
            
        }



        public ActionResult Create()
        {
            ViewBag.xx = new SelectList(bs.Roles, "Id", "Roles_name");
            return View("Userform");
        }





        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User table)
        {
            if (ModelState.IsValid)
            {
                bs.Users.Add(table);
                bs.SaveChanges();
                return RedirectToAction("Index","User");
            }

            return View("Userform", table);
        }
        public ActionResult Edit(int? id)
        {

            User user = bs.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User UU)
        {
            if (ModelState.IsValid)
            {
                bs.Entry(UU).State = EntityState.Modified;
                bs.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(UU);
        }
        // GET: Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            User UU = bs.Users.Find(id);
            if (UU == null)
            {
                return HttpNotFound();
            }
            return View(UU);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User UU = bs.Users.Find(id);
            bs.Users.Remove(UU);
            bs.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult USERE()
        {
            return View();
        }
        public ActionResult Signin()
        {
            return View();
        }
    }
}