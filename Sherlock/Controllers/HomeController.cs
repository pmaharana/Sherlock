using Sherlock.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Sherlock.ViewModels;


namespace Sherlock.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public async Task<ActionResult> Index()
        {
            return View(await db.Landmarks.ToListAsync());
        }

        [System.Web.Mvc.Authorize]
        public async Task<ActionResult> About() //Takes logged in users only, allows users to create landmark
        {
            return View(await db.Landmarks.ToListAsync());
        }



        public async Task<ActionResult> Contact()    //this is the list of landmarks 
        {
            return View(await db.Landmarks.Include(i => i.User).ToListAsync());
        }

        public ActionResult Info()
        {
            return View();
        }


        public async Task<ActionResult> LandmarkComments(int? id)
        {
            Landmark landmark = await db.Landmarks.FindAsync(id);
            var comments = await db.Comments.Include(c => c.Landmark).Include(c => c.User).ToListAsync();
            var votes = await db.Votes.Include(v => v.Landmark).Include(v => v.User).ToListAsync();
            var vm = new LandmarkCommentsViewModel { Landmark = landmark, Comments = comments, Votes = votes };
            return View(vm);
        }

        [HttpPut]
        public async Task<ActionResult> AddComment(Comments comment)
        {
            db.Comments.Add(comment);
            await db.SaveChangesAsync();
            var comments = await db.Comments.Include(c => c.Landmark).Include(c => c.User)
                .Where(w => w.LandmarkId == comment.LandmarkId).ToListAsync();
            return PartialView("_commentsList", comments);
        }

        [HttpDelete]
        public async Task<ActionResult> AddVote(Votes vote)
        {
            db.Votes.Add(vote);
            await db.SaveChangesAsync();
            var votes = await db.Votes.Include(c => c.Landmark).Include(c => c.User)
                .Where(w => w.LandmarkId == vote.LandmarkId).ToListAsync();

            return PartialView("_voteBlock", votes);
        }

    }
}