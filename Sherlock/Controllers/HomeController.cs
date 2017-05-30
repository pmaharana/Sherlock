using Sherlock.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

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
            return View(await db.Landmarks.ToListAsync());
        }

        public ActionResult Info()
        {
            return View();
        }



    }
}