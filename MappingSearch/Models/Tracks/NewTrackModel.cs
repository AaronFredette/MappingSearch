using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MappingSearch.Models.Tracks
{
    public class NewTrackModel
    {
        [Required]
        public string TrackName{get;set;}

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }
        
        [Required]
        public string Zip { get; set; }

        [Required]
        public string StreetAddress { get; set; }

        public string TrackWebSite { get; set; }

        public string Details { get; set; }

        public decimal TrackLength { get; set; }
    }
}