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
    public class InformationController : Controller
    {
        private LandOfStartupsContext db = new LandOfStartupsContext();

        //
        // GET: /Information/

        public ActionResult Index()
        {
            return View(db.Information.Include(i=>i.page).ToList());
        }

        //
        // GET: /Information/Details/5

        public ActionResult Details(int id = 0)
        {
            Information information = db.Information.Find(id);
            if (information == null)
            {
                return HttpNotFound();
            }
            return View(information);
        }

        //
        // GET: /Information/Create

        public ActionResult Create()
        {
            PopulatePagesDropDownList();
            return View();
        }

        //
        // POST: /Information/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Information information)
        {
            /*if (ModelState.IsValid)
            {
                db.Information.Add(information);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(information);*/

            information.page = db.Pages.Find(information.page.pageID);
            db.Information.Add(information);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        //
        // GET: /Information/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Information information = db.Information.Find(id);
            PopulatePagesDropDownList();
            if (information == null)
            {
                return HttpNotFound();
            }
            /* if (information.page != null)
             {
                 ViewBag.PageID = new SelectList(db.Information, "pageID", "name", information.page.pageID);
             }
             else
             {
                 ViewBag.PageID = new SelectList(db.Information, "pageID", "name");
             }*/
            return View(information);
        }

        //
        // POST: /Information/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Information information)
        {
            information.page = db.Pages.Find(information.page.pageID);
            var info = db.Information.Find(information.informationID);
            info.page = db.Pages.Find(information.page.pageID);
            db.Entry(info).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
            if (ModelState.IsValid)
            {
                db.Entry(information).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(information);
        }

        //
        // GET: /Information/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Information information = db.Information.Find(id);
            if (information == null)
            {
                return HttpNotFound();
            }
            return View(information);
        }

        //
        // POST: /Information/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Information information = db.Information.Find(id);
            db.Information.Remove(information);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        private void PopulatePagesDropDownList(object selectedPages = null)
        {
            var pagesQuery = from c in db.Pages
                                orderby c.name
                                select c;
            ViewBag.PageID = new SelectList(pagesQuery, "pageID", "name", selectedPages);
        }

    }
}