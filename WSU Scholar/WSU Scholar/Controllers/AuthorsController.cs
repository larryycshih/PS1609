using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using WSU_Scholar.Models;

namespace WSU_Scholar.Controllers
{
    public class AuthorsController : Controller
    {
        private ProjectDbContext db = new ProjectDbContext();

        // GET: Authors
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.FnameSortParm = sortOrder == "Firstname" ? "fname_desc" : "Firstname";
            ViewBag.LnameSortParm = String.IsNullOrEmpty(sortOrder) ? "lname_desc" : "";
            ViewBag.UniSortParm = sortOrder == "University" ? "university_desc" : "University";
            ViewBag.CampusSortParm = sortOrder == "Campus" ? "campus_desc" : "Campus";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var Author = from a in db.Author
                           select a;

            if(!String.IsNullOrEmpty(searchString))
            {
                Author = Author.Where(a => a.lname.Contains(searchString)
                                       || a.lname.Contains(searchString));

            }

            switch (sortOrder)
            {
                case "fname_desc":
                    Author = Author.OrderByDescending(a => a.campus);
                    break;
                case "Firstname":
                    Author = Author.OrderBy(a => a.campus);
                    break;
                case "campus_desc":
                    Author = Author.OrderByDescending(a => a.campus);
                    break;
                case "Campus":
                    Author = Author.OrderBy(a => a.campus);
                    break;
                case "lname_desc":
                    Author = Author.OrderByDescending(a => a.lname);
                    break;
                case "university_desc":
                    Author = Author.OrderBy(a => a.university);
                    break;
                case "University" :
                    Author = Author.OrderByDescending(a => a.university);
                    break;
                default:
                    Author = Author.OrderBy(a => a.lname);
                    break;

            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(Author.ToPagedList(pageNumber, pageSize));
        }

        // GET: Authors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = db.Author.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }

            return View(author);
        }

        // GET: Authors/Create
        public ActionResult Create()
        {
            ViewBag.schoolID = new SelectList(db.School, "ID", "schoolName");
            return View();
        }

        // POST: Authors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,title,fname,lname,schoolID,telephone,email,mobile,university,campus")] Author author)
        {
            if (ModelState.IsValid)
            {
                db.Author.Add(author);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.schoolID = new SelectList(db.School, "ID", "schoolName", author.schoolID);
            return View(author);
        }

        // GET: Authors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = db.Author.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            ViewBag.schoolID = new SelectList(db.School, "ID", "schoolName", author.schoolID);
            return View(author);
        }

        // POST: Authors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,title,fname,lname,schoolID,telephone,email,mobile,university,campus")] Author author)
        {
            if (ModelState.IsValid)
            {
                db.Entry(author).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.schoolID = new SelectList(db.School, "ID", "schoolName", author.schoolID);
            return View(author);
        }

        // GET: Authors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = db.Author.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Author author = db.Author.Find(id);
            db.Author.Remove(author);
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
