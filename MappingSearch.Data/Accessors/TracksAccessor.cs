using MappingSearch.Models;
using MappingSearch.Models.ViewModels.Tracks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MappingSearch.Data.Accessors
{
    public static class TracksAccessor
    {


        public static int AddTrack(Data.Track loc)
        {
           using(ReviewsDataContext context = new ReviewsDataContext())
           {
                context.Tracks.InsertOnSubmit(loc);
                context.SubmitChanges();

                return loc.TrackId;
           }
        }

        public static List<Location> GetAllTracks()
        {
            using (ReviewsDataContext context = new ReviewsDataContext())
            {
                var list = (from track in context.Tracks
                            where track.Approved
                            select new Location
                            {
                                Approved = true,
                                City = track.City,
                                Details = track.Details,
                                Id = track.TrackId,
                                Lat = track.Lat,
                                Lon = track.Long,
                                Name = track.Name,
                                State = track.State,
                                StreetAddress = track.StreetAddress,
                                SubmittedBy = track.SubmittedBy,
                                Url = track.TrackWebsite,
                                Zip = track.ZipCode,
                                TrackLength = track.TrackLength.HasValue ? track.TrackLength.Value : -1
                            }).ToList();
                
                return list;

            }
        }

        public static List<Location> GetTracksInState(string state)
        {
            using (ReviewsDataContext context = new ReviewsDataContext())
            {
                var list = (from track in context.Tracks
                            where track.Approved && track.State.Equals(state)
                            select new Location
                            {
                                Approved = true,
                                City = track.City,
                                Details = track.Details,
                                Id = track.TrackId,
                                Lat = track.Lat,
                                Lon = track.Long,
                                Name = track.Name,
                                State = track.State,
                                StreetAddress = track.StreetAddress,
                                SubmittedBy = track.SubmittedBy,
                                Url = track.TrackWebsite,
                                Zip = track.ZipCode,
                                TrackLength = track.TrackLength.HasValue? track.TrackLength.Value : -1
                            }).ToList();
                return list;
            }

            
        }

        public static Location GetTrackById(int id, string user)
        {
            using (ReviewsDataContext context = new ReviewsDataContext())
            {
                var trackDetails = (from track in context.Tracks
                            where (track.Approved || String.Equals(track.SubmittedBy,user))&& track.TrackId== id
                            select new Location
                            {
                                Approved = true,
                                City = track.City,
                                Details = track.Details,
                                Id = track.TrackId,
                                Lat = track.Lat,
                                Lon = track.Long,
                                Name = track.Name,
                                State = track.State,
                                StreetAddress = track.StreetAddress,
                                SubmittedBy = track.SubmittedBy,
                                Url = track.TrackWebsite,
                                Zip = track.ZipCode,
                                TrackLength = track.TrackLength.HasValue ? track.TrackLength.Value : -1,
                                VisibleToUser = track.SubmittedBy.Equals(user) || track.Approved,
                            }).FirstOrDefault();
                return trackDetails;
            }
        }

        public static List<Location> AllUnapprovedTracks()
        {
            using (ReviewsDataContext context = new ReviewsDataContext())
            {
                List<Location> locations =
                    (from track in context.Tracks
                     where !track.Approved
                     select new Location
                     {
                         City = track.City,
                         State = track.State,
                         Name = track.Name,
                         Details = track.Details,
                         StreetAddress = track.StreetAddress,
                         SubmittedBy = track.SubmittedBy,
                         Id= track.TrackId,
                         Url = track.TrackWebsite,
                         TrackLength = track.TrackLength.Value,
                         Zip = track.ZipCode,
                     }).ToList();

                return locations;
            }
        }
    }
}
