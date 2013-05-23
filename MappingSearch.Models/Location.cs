using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MappingSearch.Models
{
    public class Location
    {
        public string Name { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string StreetAdd { get; set; }
        public string Details { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public int Id { get; set; }
        public double DistanceFromYou {get ; set;}
    }
}