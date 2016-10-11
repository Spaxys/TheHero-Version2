using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using hero2.Entities;
using hero2.Models;

namespace hero2.Areas.GameArea.Controllers
{
    public class SlideController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: GameArea/ViewTemplates
        public ActionResult Index()
        {
            return View(db.ViewTemplates.ToList());
        }

        // GET: GameArea/ViewTemplates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slide viewTemplate = db.ViewTemplates.Find(id);
            if (viewTemplate == null)
            {
                return HttpNotFound();
            }
            return View(viewTemplate);
        }

        // GET: GameArea/ViewTemplates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GameArea/ViewTemplates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ViewType")] Slide viewTemplate)
        {
            if (ModelState.IsValid)
            {
                db.ViewTemplates.Add(viewTemplate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(viewTemplate);
        }

        // GET: GameArea/ViewTemplates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slide viewTemplate = db.ViewTemplates.Find(id);
            if (viewTemplate == null)
            {
                return HttpNotFound();
            }
            return View(viewTemplate);
        }

        // POST: GameArea/ViewTemplates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ViewType")] Slide viewTemplate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(viewTemplate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viewTemplate);
        }

        // GET: GameArea/ViewTemplates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slide viewTemplate = db.ViewTemplates.Find(id);
            if (viewTemplate == null)
            {
                return HttpNotFound();
            }
            return View(viewTemplate);
        }

        // POST: GameArea/ViewTemplates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Slide viewTemplate = db.ViewTemplates.Find(id);
            db.ViewTemplates.Remove(viewTemplate);
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
