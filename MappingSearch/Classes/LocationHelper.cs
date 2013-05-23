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
            loc = SetLongitudeAndLatitude(loc);
            loc.Id = 5;//create index column in db that will handle this
            return loc;
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