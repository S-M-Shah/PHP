using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class ContactController : Controller
    {
        Database1Entities1 bs = new Database1Entities1();
        // GET: Contact
        public ActionResult Index()
        {
            if (Session != null && Session["AId"] != null)
            {
                return View("tableCNT", bs.CONTACTs.ToList());
            }
            return RedirectToAction("AdminLogin", "Admin");
        }
        public ActionResult Create()
        {
            return View("Contact");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CONTACT table)
        {
            if (ModelState.IsValid)
            {
                bs.CONTACTs.Add(table);
               bs.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("contact", table);
        }
        public ActionResult Edit(int? id)
        {

            CONTACT user = bs.CONTACTs.Find(id);
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
        public ActionResult Edit(CONTACT co)
        {
            if (ModelState.IsValid)
            {
                bs.Entry(co).State = EntityState.Modified;
                bs.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(co);
        }
        // GET: Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            CONTACT co = bs.CONTACTs.Find(id);
            if (co == null)
            {
                return HttpNotFound();
            }
            return View(co);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CONTACT co = bs.CONTACTs.Find(id);
            bs.CONTACTs.Remove(co);
            bs.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}