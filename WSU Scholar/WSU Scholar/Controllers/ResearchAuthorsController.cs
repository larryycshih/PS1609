using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WSU_Scholar.Models;

namespace WSU_Scholar.Controllers
{
    public class ResearchAuthorsController : Controller
    {
        private ProjectDbContext db = new ProjectDbContext();

        // GET: ResearchAuthors
        public ActionResult Index()
        {
            var researchAuthor = db.ResearchAuthor.Include(r => r.Author).Include(r => r.Research);
            return View(researchAuthor.ToList());
        }

        // GET: ResearchAuthors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResearchAuthor researchAuthor = db.ResearchAuthor.Find(id);
            if (researchAuthor == null)
            {
                return HttpNotFound();
            }
            return View(researchAuthor);
        }

        // GET: ResearchAuthors/Create
        public ActionResult Create()
        {
            ViewBag.authorID = new SelectList(db.Author, "ID", "fname");
            ViewBag.researchID = new SelectList(db.Research, "ID", "title");
            return View();
        }

        // POST: ResearchAuthors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,researchID,authorID")] ResearchAuthor researchAuthor)
        {
            if (ModelState.IsValid)
            {
                db.ResearchAuthor.Add(researchAuthor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.authorID = new SelectList(db.Author, "ID", "fname", researchAuthor.authorID);
            ViewBag.researchID = new SelectList(db.Research, "ID", "title", researchAuthor.researchID);
            return View(researchAuthor);
        }

        // GET: ResearchAuthors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResearchAuthor researchAuthor = db.ResearchAuthor.Find(id);
            if (researchAuthor == null)
            {
                return HttpNotFound();
            }
            ViewBag.authorID = new SelectList(db.Author, "ID", "fname", researchAuthor.authorID);
            ViewBag.researchID = new SelectList(db.Research, "ID", "title", researchAuthor.researchID);
            return View(researchAuthor);
        }

        // POST: ResearchAuthors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,researchID,authorID")] ResearchAuthor researchAuthor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(researchAuthor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.authorID = new SelectList(db.Author, "ID", "fname", researchAuthor.authorID);
            ViewBag.researchID = new SelectList(db.Research, "ID", "title", researchAuthor.researchID);
            return View(researchAuthor);
        }

        // GET: ResearchAuthors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResearchAuthor researchAuthor = db.ResearchAuthor.Find(id);
            if (researchAuthor == null)
            {
                return HttpNotFound();
            }
            return View(researchAuthor);
        }

        // POST: ResearchAuthors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ResearchAuthor researchAuthor = db.ResearchAuthor.Find(id);
            db.ResearchAuthor.Remove(researchAuthor);
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
