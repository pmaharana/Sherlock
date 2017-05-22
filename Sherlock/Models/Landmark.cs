using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public DateTime? DateAdded { get; set; }

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




    }
}