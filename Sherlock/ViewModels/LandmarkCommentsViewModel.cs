using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sherlock.Models;

namespace Sherlock.ViewModels
{
    public class LandmarkCommentsViewModel
    {
        public Landmark Landmark { get; set; }
        public ICollection<Comments> Comments { get; set; }
    }
}