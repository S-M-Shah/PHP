using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class CategoryController : Controller
    {
        Database1Entities1 db = new Database1Entities1();
        // GET: Category
        public ActionResult Index()
        {
            if (Session != null && Session["AId"] != null)
            {
                return View("tableC", db.CATEGORies.ToList());
            }
            return RedirectToAction("AdminLogin", "Admin");
        }
        public ActionResult Create()
        {
            return View("formC");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CATEGORY table)
        {
            if (ModelState.IsValid)
            {
                db.CATEGORies.Add(table);
                db.SaveChanges();
                return RedirectToAction("Index", "User");
            }

            return View("formC", table);
        }
        public ActionResult Edit(int? id)
        {
            
            CATEGORY user = db.CATEGORies.Find(id);
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
        public ActionResult Edit(CATEGORY c)
        {
            if (ModelState.IsValid)
            {
                db.Entry(c).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           
            return View(c);
        }
        // GET: Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            CATEGORY c = db.CATEGORies.Find(id);
            if (c == null)
            {
                return HttpNotFound();
            }
            return View(c);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CATEGORY c = db.CATEGORies.Find(id);
            db.CATEGORies.Remove(c);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
     
        }
}