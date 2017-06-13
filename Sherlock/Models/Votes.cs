using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sherlock.Models
{
    public class Votes
    {
        public int Id { get; set; }
        public int Value { get; set; }

        public DateTime DateCasted { get; set; } = DateTime.Now;

        public int LandmarkId { get; set; }
        public Landmark Landmark { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        

    }
}