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
    public class ResearchesController : Controller
    {
        private ProjectDbContext db = new ProjectDbContext();

        // GET: Researches
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewBag.SubjectSortParm = sortOrder == "Subject" ? "subject_desc" : "Subject";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.GrantSortParm = sortOrder == "Grant" ? "grant_desc" : "Grant";
            ViewBag.ViewsSortParm = sortOrder == "Views" ? "views_desc" : "Views";
            ViewBag.DownloadsSortParm = sortOrder == "Downloads" ? "downloads_desc" : "Downloads";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            
            var Research = from r in db.Research
                           select r;


            if (!String.IsNullOrEmpty(searchString))
            {
                Research = Research.Where(r => r.title.Contains(searchString)
                                       || r.title.Contains(searchString));

            }

            switch (sortOrder)
            {
                case "views_desc":
                    Research = Research.OrderByDescending(r => r.views);
                    break;
                case "Views":
                    Research = Research.OrderBy(r => r.views);
                    break;
                case "downloads_desc":
                    Research = Research.OrderByDescending(r => r.downloads);
                    break;
                case "Downloads":
                    Research = Research.OrderBy(r => r.downloads);
                    break;
                case "subject_desc":
                    Research = Research.OrderByDescending(r => r.subject);
                    break;
                case "Subject":
                    Research = Research.OrderBy(r => r.subject);
                    break;
                case "grant_desc":
                    Research = Research.OrderByDescending(r => r.grants);
                    break;
                case "Grant":
                    Research = Research.OrderBy(r => r.grants);
                    break;
                case "title_desc":
                    Research = Research.OrderByDescending(r => r.title);
                    break;
                case "date_desc":
                    Research = Research.OrderByDescending(r => r.publishedDate);
                    break;
                case "Date":
                    Research = Research.OrderBy(r => r.publishedDate);
                    break;
                default:
                    Research = Research.OrderBy(r => r.title);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(Research.ToPagedList(pageNumber, pageSize));
        }

        // GET: Researches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Research research = db.Research.Find(id);
            if (research == null)
            {
                return HttpNotFound();
            }
            return View(research);
        }

        // GET: Researches/Create
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.Record, "researchID", "fileID");
            ViewBag.schoolID = new SelectList(db.School, "ID", "schoolName");
            return View();
        }

        // POST: Researches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,title,schoolID,publishedDate,subject,grants,views,downloads,abstracts")] Research research)
        {
            if (ModelState.IsValid)
            {
                db.Research.Add(research);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID = new SelectList(db.Record, "researchID", "fileID", research.ID);
            ViewBag.schoolID = new SelectList(db.School, "ID", "schoolName", research.schoolID);
            return View(research);
        }

        // GET: Researches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Research research = db.Research.Find(id);
            if (research == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = new SelectList(db.Record, "researchID", "fileID", research.ID);
            ViewBag.schoolID = new SelectList(db.School, "ID", "schoolName", research.schoolID);
            return View(research);
        }

        // POST: Researches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,title,schoolID,publishedDate,subject,grants,views,downloads,abstracts")] Research research)
        {
            if (ModelState.IsValid)
            {
                db.Entry(research).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.Record, "researchID", "fileID", research.ID);
            ViewBag.schoolID = new SelectList(db.School, "ID", "schoolName", research.schoolID);
            return View(research);
        }

        // GET: Researches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Research research = db.Research.Find(id);
            if (research == null)
            {
                return HttpNotFound();
            }
            return View(research);
        }

        // POST: Researches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Research research = db.Research.Find(id);
            db.Research.Remove(research);
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
