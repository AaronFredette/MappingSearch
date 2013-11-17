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
using MappingSearch.Models.ViewModels.Tracks;
using MappingSearch.Models.Tracks;
using MappingSearch.Models.ViewModels;
using MappingSearch.Constants.ViewConstants;


namespace MappingSearch.Classes.Track
{
    public static class TrackHelper
    {
        private const string GOOGLE_API = "https://maps.googleapis.com/maps/api/geocode/json?sensor=false&components=postal_code:{0}";
      

        internal static int AddTrack(NewTrackModel newLocation)
        {
            Data.Track loc = CreateLocationFromNewLocationModel(newLocation);

            return Data.Accessors.TracksAccessor.AddTrack(loc);
        }

        internal static MappingSearch.Data.Track CreateLocationFromNewLocationModel(NewTrackModel newLocation)
        {
            Data.Track track = new Data.Track();
            track.City = FormInputHelper.StripInput(newLocation.City);
            track.Details = FormInputHelper.StripInput(newLocation.Details);
            track.State = FormInputHelper.StripInput(newLocation.State);
            track.ZipCode = FormInputHelper.StripInput(newLocation.Zip);
            track.StreetAddress = FormInputHelper.StripInput(newLocation.StreetAddress);
            
            GoogleGeoCodeResponse latLong = GetLatLongOfZip(newLocation.Zip);
            track.Name = FormInputHelper.StripInput(newLocation.TrackName);
            track.Lat = Convert.ToDouble(latLong.results[0].geometry.location.lat);
            track.Long = Convert.ToDouble(latLong.results[0].geometry.location.lng);
            track.TrackLength = newLocation.TrackLength;
            track.Approved = false;
            track.TrackWebsite = CorrectSiteUrl(newLocation.TrackWebSite);
            track.SubmittedBy = System.Web.HttpContext.Current.User.Identity.Name;

            return track;
            
        }

        internal static string CorrectSiteUrl(string url)
        {
           string cleanUrl = !url.Contains("http://") || !url.Contains("https://") ? String.Format("http://{0}", url) : url;
           bool goodUri = Uri.IsWellFormedUriString(cleanUrl, UriKind.Absolute);
            return cleanUrl;
        }

        
       

        internal static ResponseModel<List<Location>> FindLocationsInDistance(string zip, int distance, int start,int end)
        {
            GoogleGeoCodeResponse coord = GetLatLongOfZip(zip);
            List<Location> allLocations = Data.Accessors.TracksAccessor.GetAllTracks();
            List<Location> filteredLocations;
            if (coord.results.Length > 0)
                filteredLocations = FilterLocationsFromList(allLocations, distance, Convert.ToDouble(coord.results[0].geometry.location.lat),Convert.ToDouble(coord.results[0].geometry.location.lng)).OrderBy(x=>x.Name).ToList();
            else
                filteredLocations = new List<Location>();


            ResponseModel<List<Location>> response = new ResponseModel<List<Location>>();
            response.PageCount = filteredLocations.Count() / PageCountConstants.MAX_TRACKS;
            end = filteredLocations.Count > end ? end : filteredLocations.Count;
            response.Model = filteredLocations.Skip(start).Take(end).Select(x => x).ToList();
            return response;
            
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

        internal static ResponseModel<List<Location>> GetAllLocations(int start, int end)
        {
            ResponseModel<List<Location>> response = new ResponseModel<List<Location>>();
            List<Location> rawTracks = new List<Location>();

            rawTracks = Data.Accessors.TracksAccessor.GetAllTracks().OrderBy(x=>x.Name).ToList();
            response.PageCount = rawTracks.Count() / PageCountConstants.MAX_TRACKS;
            end = rawTracks.Count > end ? end : rawTracks.Count;
            response.Model =  rawTracks.Skip(start).Take(end).Select(x => x).ToList();
            return response;
           
        }

        internal static ResponseModel<List<Location>> SearchStateLocations(string state, int start, int end)
        {
            List<Location> filteredLocations = Data.Accessors.TracksAccessor.GetTracksInState(state).OrderBy(x=>x.Name).ToList();
            ResponseModel<List<Location>> response = new ResponseModel<List<Location>>();
            response.PageCount = filteredLocations.Count()/PageCountConstants.MAX_TRACKS;

            end = filteredLocations.Count > end ? end : filteredLocations.Count;

            response.Model =  filteredLocations.Skip(start).Take(end).Select(x => x).ToList();
            return response;
            
        }

        internal static Location GetTrackDetails(int id)
        {
            Location loc = Data.Accessors.TracksAccessor.GetTrackById(id,CurrentUser.Identitiy());
            if (loc != null)
                return loc;
            return null;
        }
    }
}