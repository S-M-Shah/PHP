using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;
using System.Data.Entity;


namespace WebApplication3.Controllers
{
    public class ArcheiveController : Controller
    {
        Database1Entities1 db = new Database1Entities1();
        // GET: Archeive
        public ActionResult Index()
        {
            if (Session != null && Session["AId"] != null)
            {
                return View("Arch", db.Acheivs.ToList());
            }
            return RedirectToAction("AdminLogin", "Admin");
        }
        public ActionResult Create()
        {
            return View("Archform");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Acheiv table, HttpPostedFileBase img)
        {
            String imgUrl = "";
            if (img.ContentLength > 0)
            {
                img.SaveAs(Server.MapPath("~/upload/" + img.FileName));
                imgUrl = "~/upload/" + img.FileName;
                img.InputStream.Close();
                img.InputStream.Dispose();
            }

            if (ModelState.IsValid)
            {
                table.pic = imgUrl;
                db.Acheivs.Add(table);
                db.SaveChanges();
                return RedirectToAction("Index", "User");
            }

            return View("Archform",table);
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int? id)
        {
           
            Acheiv aa = db.Acheivs.Find(id);
            if (aa == null)
            {
                return HttpNotFound();
            }
            return View(aa);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Acheiv aa, HttpPostedFileBase img)
        {
            string img_url = "";
            if (img != null)
            {
                if (img.ContentLength > 0)
                {
                    img.SaveAs(Server.MapPath("~/upload/" + img.FileName)); // taking image to folder
                    img_url = "~/upload/" + img.FileName; //saving path in a variable
                    img.InputStream.Close();
                    img.InputStream.Dispose();
                }
            }

            if (ModelState.IsValid)
            {
                db.Entry(aa).State = EntityState.Modified;
                if (img == null)
                    db.Entry(aa).Property(m => m.pic).IsModified = false;
                else
                    aa.pic = img_url;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aa);
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int? id)
        {
           Acheiv  aa = db.Acheivs.Find(id);
            if (aa == null)
            {
                return HttpNotFound();
            }
            return View(aa);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Acheiv aa = db.Acheivs.Find(id);
            db.Acheivs.Remove(aa);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }



    }
}