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
    public class LandmarksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Landmarks
        public async Task<ActionResult> Index()
        {
            var landmarks = db.Landmarks.Include(l => l.Category).Include(l => l.User);
            return View(await landmarks.ToListAsync());
        }

        // GET: Landmarks/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Landmark landmark = await db.Landmarks.FindAsync(id);
            if (landmark == null)
            {
                return HttpNotFound();
            }
            return View(landmark);
        }

        // GET: Landmarks/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: Landmarks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Title,Description,Latitude,Longitude,DateAdded,Address1,Address2,City,State,Country,ZipCode,Image1,Video,Media2,Media3,Media4,Links,UserId,CategoryId,IsFavorite")] Landmark landmark)
        {
            if (ModelState.IsValid)
            {
                db.Landmarks.Add(landmark);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", landmark.CategoryId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", landmark.UserId);
            return View(landmark);
        }

        // GET: Landmarks/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Landmark landmark = await db.Landmarks.FindAsync(id);
            if (landmark == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", landmark.CategoryId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", landmark.UserId);
            return View(landmark);
        }

        // POST: Landmarks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Title,Description,Latitude,Longitude,DateAdded,Address1,Address2,City,State,Country,ZipCode,Image1,Video,Media2,Media3,Media4,Links,UserId,CategoryId,IsFavorite")] Landmark landmark)
        {
            if (ModelState.IsValid)
            {
                db.Entry(landmark).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", landmark.CategoryId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", landmark.UserId);
            return View(landmark);
        }

        // GET: Landmarks/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Landmark landmark = await db.Landmarks.FindAsync(id);
            if (landmark == null)
            {
                return HttpNotFound();
            }
            return View(landmark);
        }

        // POST: Landmarks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Landmark landmark = await db.Landmarks.FindAsync(id);
            db.Landmarks.Remove(landmark);
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
