using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sherlock.Models;

namespace Sherlock.Controllers
{
    public class CommentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Comments
        public async Task<ActionResult> Index()
        {
            var comments = db.Comments.Include(c => c.Landmark).Include(c => c.User);
            return View(await comments.ToListAsync());
        }

        // GET: Comments/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comments comments = await db.Comments.FindAsync(id);
            if (comments == null)
            {
                return HttpNotFound();
            }
            return View(comments);
        }

        // GET: Comments/Create
        public ActionResult Create()
        {
            ViewBag.LandmarkId = new SelectList(db.Landmarks, "Id", "Title");
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Body,DateAdded,Image,LandmarkId,UserId")] Comments comments)
        {
            if (ModelState.IsValid)
            {
                db.Comments.Add(comments);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.LandmarkId = new SelectList(db.Landmarks, "Id", "Title", comments.LandmarkId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", comments.UserId);
            return View(comments);
        }

        // GET: Comments/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comments comments = await db.Comments.FindAsync(id);
            if (comments == null)
            {
                return HttpNotFound();
            }
            ViewBag.LandmarkId = new SelectList(db.Landmarks, "Id", "Title", comments.LandmarkId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", comments.UserId);
            return View(comments);
        }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Body,DateAdded,Image,LandmarkId,UserId")] Comments comments)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comments).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.LandmarkId = new SelectList(db.Landmarks, "Id", "Title", comments.LandmarkId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", comments.UserId);
            return View(comments);
        }

        // GET: Comments/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comments comments = await db.Comments.FindAsync(id);
            if (comments == null)
            {
                return HttpNotFound();
            }
            return View(comments);
        }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Comments comments = await db.Comments.FindAsync(id);
            db.Comments.Remove(comments);
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
