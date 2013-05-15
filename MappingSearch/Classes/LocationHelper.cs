using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;

namespace MappingSearch.Classes
{
    public class LocationHelper
    {
        private const string GOOGLE_API = "https://maps.googleapis.com/maps/api/geocode/json?sensor=false&components=postal_code:{0}";
        public static Location SetLongitudeAndLatitude(Location loc)
        {
            //LookUpLatLon(city,state,street); online api?
            Random rand = new Random();
            loc.Lon = rand.NextDouble() * (100 - 1) + 1;
            loc.Lat = rand.NextDouble() * (100 - 1) + 1;

            return loc;
        }

        internal static Location InitializeLocation(Location loc)
        {
            loc = SetLongitudeAndLatitude(loc);
            loc.Id = 5;//create index column in db that will handle this
            return loc;
        }

        internal static void FindLocationsInDistance(string zip, int distance)
        {
            Coordinates coord = GetLatLongOfZip(zip);
        }

        private static Coordinates GetLatLongOfZip(string zip)
        {
            string requestUrl = String.Format(GOOGLE_API, zip);
            WebRequest webReq = WebRequest.Create(requestUrl);
            Coordinates coord = new Coordinates();
            string response;
            try
            {
                response = new WebClient().DownloadString(requestUrl);
                var json_serializer = new JavaScriptSerializer();
                var locationData = (IDictionary<string, object>)json_serializer.DeserializeObject(response);
            }
            catch (Exception e)
            {
                throw;
            }
            return coord;
        }
    }

    private class Coordinates {
        double Latitude { get; set; }
        double Longitude { get; set; }
    }
}