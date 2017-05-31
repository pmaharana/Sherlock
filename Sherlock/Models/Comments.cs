using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sherlock.Models
{
    public class Comments
    {
        public int Id { get; set; }
        public string Body { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yy}", ApplyFormatInEditMode = true)]
        public DateTime? DateAdded { get; set; } = DateTime.Now;

        public string Image { get; set; }

        public int LandmarkId { get; set; }
        public Landmark Landmark { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        


    }
}