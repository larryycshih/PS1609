using Research_Portal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Research_Portal.Controllers
{
    public class SchoolsController : Controller
    {

     
        // GET: Schools
        public ActionResult Index()
        {


                return View();

        }

       
        // GET: Schools/Details/
        public ActionResult Details()
        {
            var stub = new School { schoolName = "thisefe" };
            return View(stub);
        }

        // GET: Schools/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Schools/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                using (ProjectDbContext context = new ProjectDbContext())
                {
                    context.School.Add(new School { schoolName = "school 1" });
                }
            }
            

                return View();
        }

        // GET: Schools/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Schools/Edit/5
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

        // GET: Schools/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Schools/Delete/5
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
