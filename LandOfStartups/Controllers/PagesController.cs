using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LandOfStartups.Controllers
{
    public class PagesController : Controller
    {

        public ActionResult growth()
        {
            return View();
        }

        public ActionResult fundraising()
        {
            return View();
        }

        public ActionResult team()
        {
            return View();
        }

        public ActionResult planning()
        {
            return View();
        }

        public ActionResult technologies()
        {
            return View();
        }

        public ActionResult marketing()
        {
            return View();
        }

        public ActionResult legalities()
        {
            return View();
        }

        public ActionResult intro()
        {
            return View();
        }

        //
        // GET: /Pages/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Pages/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Pages/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Pages/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Pages/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Pages/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Pages/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Pages/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
