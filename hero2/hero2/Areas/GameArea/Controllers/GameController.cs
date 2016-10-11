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
using hero2.Logic;
using System.Threading.Tasks;

namespace hero2.Areas.GameArea.Controllers
{
    public class GameController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: GameArea/GameTemplates
        public ActionResult Index()
        {
            return View(db.GameTemplates.ToList());
        }
        public async Task<ActionResult> StartGame(int gameId)
        {
            if (gameId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var game = await db.GameTemplates.FindAsync(gameId);
            if(game == null)
            {
                return HttpNotFound();
            }

            //The db table async method
            //var model = await db.ViewTemplates.FindAsync(game.StartView);
            //The collection method
            var model = game.Views.First(v => v.Id.Equals(game.StartView));
            if(model == null)
            {
                return View();
            }

            return View("ViewSlide", model);
        }


        public async Task<ActionResult> ViewSlide(int slideId)
        {
            if (slideId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //Look for the next slide
            
            var model = await db.ViewTemplates.FindAsync(slideId);


            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        //[HttpPost]
        //public ActionResult NextSlide([Bind(Include = "Id,")] int gameId, int slideId)
        //{
        //    if (gameId == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    var game = db.GameTemplates.Find(gameId);
        //    if (game == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    //Look for the next slide

        //    if (slideId == -1)
        //        return View("EndGame");
        //    return View(id);
        //}

        public ActionResult EndGame()
        {
            return View(db.GameTemplates.ToList());
        }


        // GET: GameArea/GameTemplates/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game gameTemplate = db.GameTemplates.Find(id);
            if (gameTemplate == null)
            {
                return HttpNotFound();
            }
            return View(gameTemplate);
        }

        // GET: GameArea/GameTemplates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GameArea/GameTemplates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StartView,EndView")] Game gameTemplate)
        {
            if (ModelState.IsValid)
            {
                //gameTemplate.Id = Guid.NewGuid();
                db.GameTemplates.Add(gameTemplate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gameTemplate);
        }

        // GET: GameArea/GameTemplates/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game gameTemplate = db.GameTemplates.Find(id);
            if (gameTemplate == null)
            {
                return HttpNotFound();
            }
            return View(gameTemplate);
        }

        // POST: GameArea/GameTemplates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id")] Game gameTemplate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gameTemplate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gameTemplate);
        }

        // GET: GameArea/GameTemplates/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game gameTemplate = db.GameTemplates.Find(id);
            if (gameTemplate == null)
            {
                return HttpNotFound();
            }
            return View(gameTemplate);
        }

        // POST: GameArea/GameTemplates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Game gameTemplate = db.GameTemplates.Find(id);
            db.GameTemplates.Remove(gameTemplate);
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
