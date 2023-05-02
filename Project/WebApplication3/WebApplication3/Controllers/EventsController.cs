using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;
using System.Data.Entity;
namespace WebApplication3.Controllers
{
    public class EventsController : Controller
    {
        Database1Entities1 bs = new Database1Entities1();
        // GET: Events
        public ActionResult Index()
        {
            if (Session != null && Session["AId"] != null)
            {
                return View("tableE", bs.EVENTS.ToList());
        }
            return RedirectToAction("AdminLogin", "Admin");
    }
        public ActionResult Create()
        {
            return View("formE");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EVENT table)
        {
            if (ModelState.IsValid)
            {
                bs.EVENTS.Add(table);
                bs.SaveChanges();
                return RedirectToAction("Index", "User");
            }

            return View("formE", table);
        }
        public ActionResult Edit(int? id)
        {

            EVENT user = bs.EVENTS.Find(id);
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
        public ActionResult Edit(EVENT ee)
        {
            if (ModelState.IsValid)
            {
                bs.Entry(ee).State = EntityState.Modified;
                bs.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ee);
        }
        // GET: Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            EVENT ee = bs.EVENTS.Find(id);
            if (ee == null)
            {
                return HttpNotFound();
            }
            return View(ee);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EVENT ee = bs.EVENTS.Find(id);
            bs.EVENTS.Remove(ee);
            bs.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}