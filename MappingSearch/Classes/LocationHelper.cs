using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MappingSearch.Classes
{
    public class LocationHelper
    {
        public static Location SetLongitudeAndLatitude(Location loc)
        {
            //LookUpLatLon(city,state,street); online api?
            Random rand = new Random();
            loc.Lon = rand.NextDouble()*(100 - 1) + 1;
            loc.Lat = rand.NextDouble() * (100 - 1) + 1;

            return loc;
        }

        internal static Location InitializeLocation(Location loc)
        {
            loc = SetLongitudeAndLatitude(loc);
            loc.Id = 5;//create index column in db that will handle this
            return loc;
        }
    }
}