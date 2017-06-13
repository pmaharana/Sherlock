using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Sherlock.Models;

namespace Sherlock.Controllers
{
    public class VotesAPIController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/VotesAPI
        public IQueryable<Votes> GetVotes()
        {
            return db.Votes;
        }

        // GET: api/VotesAPI/5
        [ResponseType(typeof(Votes))]
        public async Task<IHttpActionResult> GetVotes(int id)
        {
            Votes votes = await db.Votes.FindAsync(id);
            if (votes == null)
            {
                return NotFound();
            }

            return Ok(votes);
        }

        // PUT: api/VotesAPI/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutVotes(int id, Votes votes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != votes.Id)
            {
                return BadRequest();
            }

            db.Entry(votes).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VotesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/VotesAPI
        [ResponseType(typeof(Votes))]
        public async Task<IHttpActionResult> PostVotes(Votes votes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Votes.Add(votes);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = votes.Id }, votes);
        }

        // DELETE: api/VotesAPI/5
        [ResponseType(typeof(Votes))]
        public async Task<IHttpActionResult> DeleteVotes(int id)
        {
            Votes votes = await db.Votes.FindAsync(id);
            if (votes == null)
            {
                return NotFound();
            }

            db.Votes.Remove(votes);
            await db.SaveChangesAsync();

            return Ok(votes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VotesExists(int id)
        {
            return db.Votes.Count(e => e.Id == id) > 0;
        }
    }
}