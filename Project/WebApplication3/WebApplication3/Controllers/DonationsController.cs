using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;
using System.Data.Entity;
namespace WebApplication3.Controllers
{
    public class DonationsController : Controller
    {
        Database1Entities1 bs = new Database1Entities1();
        // GET: Donations
        public ActionResult Index()
        {
            if (Session != null && Session["AId"] != null)
            {
                return View("tableD", bs.DONATIONS.ToList());
            }
            return RedirectToAction("AdminLogin", "Admin");
        }
        public ActionResult Create()
        {
            return View("Donate");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DONATION table)
        {
            if (ModelState.IsValid)
            {
                bs.DONATIONS.Add(table);
                bs.SaveChanges();
                return RedirectToAction("Index","User");
            }

            return View("Donate", table);
        }
        public ActionResult Edit(int? id)
        {

            DONATION user = bs.DONATIONS.Find(id);
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
        public ActionResult Edit(DONATION dd)
        {
            if (ModelState.IsValid)
            {
                bs.Entry(dd).State = EntityState.Modified;
                bs.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dd);
        }
        // GET: Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            DONATION dd = bs.DONATIONS.Find(id);
            if (dd == null)
            {
                return HttpNotFound();
            }
            return View(dd);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DONATION dd = bs.DONATIONS.Find(id);
            bs.DONATIONS.Remove(dd);
            bs.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}