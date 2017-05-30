using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sherlock.Models
{
    public class Landmark
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yy}", ApplyFormatInEditMode = true)]
        public DateTime? DateAdded { get; set; } = DateTime.Now;

        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int? ZipCode { get; set; }

        public string Image1 { get; set; }
        public string Video { get; set; }
        public string Media2 { get; set; }
        public string Media3 { get; set; }
        public string Media4 { get; set; }
        public string Links { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User{ get; set; }

        public virtual ICollection<Votes> Vote { get; set; } = new HashSet<Votes>();

        public virtual ICollection<Comments> Comments { get; set; } = new HashSet<Comments>();

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public bool IsFavorite { get; set; } = false;

        //rating system out of 4 stars


    }
}