using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using hero2.Entities;
using hero2.Models;

namespace hero2.Areas.GameArea.Controllers
{
    public class ContentItemsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: GameArea/ContentItems
        public async Task<ActionResult> Index()
        {
            return View(await db.ContentItems.ToListAsync());
        }

        // GET: GameArea/ContentItems/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContentItem contentItem = await db.ContentItems.FindAsync(id);
            if (contentItem == null)
            {
                return HttpNotFound();
            }
            return View(contentItem);
        }

        // GET: GameArea/ContentItems/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GameArea/ContentItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,ViewPosition,SlideId,ContentType,Text,ImageURL,URL")] ContentItem contentItem)
        {
            if (ModelState.IsValid)
            {
                db.ContentItems.Add(contentItem);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(contentItem);
        }

        // GET: GameArea/ContentItems/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContentItem contentItem = await db.ContentItems.FindAsync(id);
            if (contentItem == null)
            {
                return HttpNotFound();
            }
            return View(contentItem);
        }

        // POST: GameArea/ContentItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ViewPosition,SlideId,ContentType,Text,ImageURL,URL")] ContentItem contentItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contentItem).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(contentItem);
        }

        // GET: GameArea/ContentItems/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContentItem contentItem = await db.ContentItems.FindAsync(id);
            if (contentItem == null)
            {
                return HttpNotFound();
            }
            return View(contentItem);
        }

        // POST: GameArea/ContentItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ContentItem contentItem = await db.ContentItems.FindAsync(id);
            db.ContentItems.Remove(contentItem);
            await db.SaveChangesAsync();
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
