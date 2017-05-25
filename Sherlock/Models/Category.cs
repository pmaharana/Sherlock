using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sherlock.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Landmark> Landmarks { get; set; } = new HashSet<Landmark>();

    }
}