using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;
using System.Data.Entity;
namespace WebApplication3.Controllers
{
    public class VolunteerController : Controller
    {
        Database1Entities1 bs = new Database1Entities1();
        // GET: Volunteer
        public ActionResult Index()
        {
            if (Session != null && Session["AId"] != null)
            {
                return View("tableV", bs.Volunteers.ToList());
            }
                return RedirectToAction("AdminLogin", "Admin");
            
        }
        public ActionResult Create()
        {
            return View("Volunteer");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Volunteer table)
        {
            if (ModelState.IsValid)
            {
                bs.Volunteers.Add(table);
                bs.SaveChanges();
                return RedirectToAction("Index", "User");
            }

            return View("Volunteer", table);
        }
        public ActionResult Edit(int? id)
        {

            Volunteer user = bs.Volunteers.Find(id);
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
        public ActionResult Edit(Volunteer VV)
        {
            if (ModelState.IsValid)
            {
                bs.Entry(VV).State = EntityState.Modified;
                bs.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(VV);
        }
        // GET: Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            Volunteer VV = bs.Volunteers.Find(id);
            if (VV == null)
            {
                return HttpNotFound();
            }
            return View(VV);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Volunteer VV = bs.Volunteers.Find(id);
            bs.Volunteers.Remove(VV);
            bs.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}