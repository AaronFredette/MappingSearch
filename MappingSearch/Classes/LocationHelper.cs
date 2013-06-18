using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using MappingSearch.Models;
using MappingSearch.Data;
using System.Reflection;
using System.Text.RegularExpressions;

namespace MappingSearch.Classes
{
    public static class LocationHelper
    {
        private const string GOOGLE_API = "https://maps.googleapis.com/maps/api/geocode/json?sensor=false&components=postal_code:{0}";
        public static MappingSearch.Models.Location SetLongitudeAndLatitude(Location loc)
        {
            //LookUpLatLon(city,state,street); online api?
            Random rand = new Random();
            loc.Lon = rand.NextDouble() * (100 - 1) + 1;
            loc.Lat = rand.NextDouble() * (100 - 1) + 1;

            return loc;
        }

        internal static Location InitializeLocation(Location loc)
        {
            loc = CleanLocation(loc);
            loc = SetLongitudeAndLatitude(loc);
            Location newLoc = MappingSearch.Data.Locations.SaveNewLocation(loc);
            loc.Url = !loc.Url.Contains("http://") || !loc.Url.Contains("https://") ? String.Format("http://{0}", loc.Url) : loc.Url;
           bool goodUri = Uri.IsWellFormedUriString(loc.Url, UriKind.Absolute);
            return newLoc;
        }

        private static Location CleanLocation(Location loc)
        {

            loc.City = StripInput(loc.City);
            loc.State = StripInput(loc.State);
            loc.Details = StripInput(loc.Details);
            loc.Zip = StripInput(loc.Zip);
            loc.StreetAdd = StripInput(loc.StreetAdd);
            return loc;
        }

        private static string StripInput(string input)
        {
            if (input == null) return String.Empty;
            return Regex.Replace(input, @"[\r\n\x00\x1a\\'""]", @"\$0");
        }

        internal static List<Location> FindLocationsInDistance(string zip, int distance)
        {
            GoogleGeoCodeResponse coord = GetLatLongOfZip(zip);
            List<Location> allLocations = Locations.GetAllLocations();
            List<Location> filteredLocations;
            if (coord.results.Length > 0)
                filteredLocations = FilterLocationsFromList(allLocations, distance, Convert.ToDouble(coord.results[0].geometry.location.lat),Convert.ToDouble(coord.results[0].geometry.location.lng));
            else
                filteredLocations = new List<Location>();


            return filteredLocations;
        }

        private static List<Location> FilterLocationsFromList(List<Location> allLocations, int distance, double lat, double lng)
        {
            int earthRadius = 6371; // km
            List<Location> filteredLoc = new List<Location>();
            var latCenter = Math.PI * lat/180;
            var lngCenter = Math.PI * lng/180;


            foreach (Location l in allLocations)
            {
                var latDest = Math.PI * l.Lat / 180;
                var lngDest = Math.PI * l.Lon / 180;
                var theata = lng - l.Lon;

                var rTheta = Math.PI * theata / 180;

                var dist = Math.Sin(latCenter) * Math.Sin(latDest) + Math.Cos(latCenter) * Math.Cos(latDest) * Math.Cos(rTheta);

                dist = Math.Acos(dist);
                dist = dist * 180/Math.PI;
                dist = dist * 60 * 1.1515;
                if (dist < distance) {
                    l.DistanceFromYou = Math.Round(dist,1);
                    filteredLoc.Add(l);
                }
            }
            return filteredLoc;
        }

        private static GoogleGeoCodeResponse GetLatLongOfZip(string zip)
        {
            string requestUrl = String.Format(GOOGLE_API, zip);
            WebRequest webReq = WebRequest.Create(requestUrl);
            GoogleGeoCodeResponse googleResponse = new GoogleGeoCodeResponse();
            string response;
            try
            {
                response = new WebClient().DownloadString(requestUrl);
                var json_serializer = new JavaScriptSerializer();
                googleResponse = JsonConvert.DeserializeObject<GoogleGeoCodeResponse>(response);                
            }
            catch (Exception e)
            {
                throw;
            }
            return googleResponse;
        }
    }
}