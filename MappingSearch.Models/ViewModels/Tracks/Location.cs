using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MappingSearch.Models.ViewModels.Tracks
{
    public class Location
    {
        public string Name { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string StreetAddress { get; set; }
        public string Details { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public int Id { get; set; }
        public double DistanceFromYou {get ; set;}
        public bool Approved { get; set; }
        public string Url { get; set; }
        public string SubmittedBy { get; set; }
        public decimal TrackLength{get;set;}
        public bool VisibleToUser { get; set; }
    }
}