using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LandOfStartups.Models;

namespace LandOfStartups.Controllers
{
    public class PageAdminController : Controller
    {
        private LandOfStartupsContext db = new LandOfStartupsContext();

        //
        // GET: /PageAdmin/

        public ActionResult Index()
        {
            return View(db.Pages.ToList());
        }

        //
        // GET: /PageAdmin/Details/5

        public ActionResult Details(int id = 0)
        {
            Page page = db.Pages.Find(id);
            if (page == null)
            {
                return HttpNotFound();
            }
            return View(page);
        }

        //
        // GET: /PageAdmin/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /PageAdmin/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Page page)
        {
            if (ModelState.IsValid)
            {
                db.Pages.Add(page);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(page);
        }

        //
        // GET: /PageAdmin/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Page page = db.Pages.Find(id);
            if (page == null)
            {
                return HttpNotFound();
            }
            return View(page);
        }

        //
        // POST: /PageAdmin/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Page page)
        {
            if (ModelState.IsValid)
            {
                db.Entry(page).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(page);
        }

        //
        // GET: /PageAdmin/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Page page = db.Pages.Find(id);
            if (page == null)
            {
                return HttpNotFound();
            }
            return View(page);
        }

        //
        // POST: /PageAdmin/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Page page = db.Pages.Find(id);
            db.Pages.Remove(page);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}