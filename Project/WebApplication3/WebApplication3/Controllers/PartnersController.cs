using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;
using System.Data.Entity;
namespace WebApplication3.Controllers
{
    public class PartnersController : Controller
    {
        Database1Entities1 bs = new Database1Entities1();
        // GET: Partners
        public ActionResult Index()
        {
            if (Session != null && Session["AId"] != null)
            {
                return View("tableP", bs.PARTNERS.ToList());
            }
            return RedirectToAction("AdminLogin", "Admin");
        }
        public ActionResult Create()
        {
            return View("formP");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PARTNER table)
        {
            if (ModelState.IsValid)
            {
                bs.PARTNERS.Add(table);
                bs.SaveChanges();
                return RedirectToAction("Index", "User");
            }

            return View("formP", table);
        }
        public ActionResult Edit(int? id)
        {

            PARTNER user = bs.PARTNERS.Find(id);
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
        public ActionResult Edit(PARTNER pp)
        {
            if (ModelState.IsValid)
            {
                bs.Entry(pp).State = EntityState.Modified;
                bs.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pp);
        }
        // GET: Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            PARTNER pp = bs.PARTNERS.Find(id);
            if (pp == null)
            {
                return HttpNotFound();
            }
            return View(pp);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PARTNER pp = bs.PARTNERS.Find(id);
            bs.PARTNERS.Remove(pp);
            bs.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}