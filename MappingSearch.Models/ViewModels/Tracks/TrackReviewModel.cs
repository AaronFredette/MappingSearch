using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MappingSearch.Models.ViewModels.Tracks
{
    public class TrackReviewModel
    {
        public Location TrackDetails { get; set; }
        public bool UserHasReviewed { get; set; }
    }
}
