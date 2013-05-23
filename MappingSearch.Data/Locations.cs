using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MappingSearch.Models;

namespace MappingSearch.Data
{
    public static class Locations
    {
        public static List<Location> GetAllLocations(){
            return new List<Location> { new Location { Details = "NH Details", Id = 1, Lat = 43.2856, Lon = -71.4673, Name = "New Hampshire", State = "NH" }, new Location { Details = "Vermont Details", Id = 2, Lat = 43.000, Lon = 71.000, Name = "Vermont", State = "VT" } };
        }

        public static List<Location> GetLocationsInDistance()
        {
            //Use linq to sql to get all locations that are +- x lat lon from given lat lon
            throw new NotImplementedException();
        }
    }
}
