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
        private static List<Location> _allLocations  = new List<Location> { new Location { Details = "NH Details", Id = 1, Lat = 43.2856, Lon = -71.4673,Url="http://www.google.com", Name = "New Hampshire", State = "NH" ,City="Loudon", StreetAdd="Some St" , Zip="12849"}, new Location { Details = "Vermont Details", Id = 2, Lat = 43.000, Lon = 71.000, Name = "Vermont", State = "VT" } };
        public static List<Location> GetAllLocations(){
            return _allLocations;
        }

        public static List<Location> GetLocationsInDistance()
        {
            //Use linq to sql to get all locations that are +- x lat lon from given lat lon
            throw new NotImplementedException();
        }

        public static List<Location> SearchStateLocations(string id)
        {
           return  _allLocations.Where(x=>String.Equals(x.State,id,StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public static Location SaveNewLocation(Location newLocation)
        { 
            //save location
            newLocation.Id = 5;
            return newLocation;
        }
    }
}
