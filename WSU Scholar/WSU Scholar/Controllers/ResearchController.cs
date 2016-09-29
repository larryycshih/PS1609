using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WSU_Scholar.Controllers
{
    public class ResearchController : Controller
    {
        // GET: Research
        public ActionResult Index()
        {
            return View();
        }

        // GET: Research/Details/5
        public ActionResult Details()//int id)
        {
            return View();
        }

        // GET: Research/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Research/Create
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

        // GET: Research/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Research/Edit/5
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

        // GET: Research/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Research/Delete/5
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
