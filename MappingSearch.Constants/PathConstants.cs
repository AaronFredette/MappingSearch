using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MappingSearch.Constants
{
   public static  class PathConstants
    {
       public static class Pages{
           public static string ReviewPathWithProductId {
               get { return"/Review/{0}/{1}";//{category}/{id}
               }
           }

           public static string TrackReviewPath
           {
               get
               {
                   return "/Tracks/Review";
               }
           }
           public static string MotrocycleCategoryPath
           {
               get { return "/Product/Category/Motorcycle"; }
           }
           public static string GearCategoryPath
           {
               get { return "/Product/Category/Gear"; }
           }
           public static string TrackCategoryPath
           {
               get { return "/Tracks"; }
           }
           
           public static string AccountLoginPath
           {
               get { return "/Account/Login"; }
           }
           public static string AddGearPath
           {
               get { return "/Product/AddGear"; }
           }
           public static string AdminPath
           {
               get { return "/Admin"; }
           }
           public static string ReviewRootPath
           {
               get { return "/Review"; }
           }
           public static string PartsAccessoriesPath
           {
               get { return "/Product/PartsAndAccessories"; }
           }

           public static string AddMotorcyclePath {
               get
               {
                   return "/Product/AddMotorcycle";
               }
           }
       }
    }
}
