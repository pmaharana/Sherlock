using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Sherlock.Models;
using System.Collections.Generic;

namespace Sherlock.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Landmark> Landmarks { get; set; } = new HashSet<Landmark>();
        public virtual ICollection<Comments> Comments { get; set; } = new HashSet<Comments>();
        public virtual ICollection<Votes> Votes { get; set; } = new HashSet<Votes>();




        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Landmark> Landmarks { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Votes> Votes { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}