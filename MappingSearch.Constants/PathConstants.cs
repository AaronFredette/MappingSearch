using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MappingSearch.Constants
{
   public static  class PathConstants
    {
       public static class Pages{
           public static string ReviewPathWithProductId = "/Review/{0}/{1}";//{category}/{id}
           public static string MotrocycleCategoryPath = "/Product/Category/Motorcycle";
           public static string GearCategoryPath = "/Product/Category/Gear";
           public static string TrackCategoryPath = "/Tracks";
           public static string AccountLoginPath = "/Account/Login";
           public static string AddGearPath = "/Product/Category/AddGear";
           public static string AdminPath = "/Admin";
           public static string ReviewRootPath = "/Review";
           public static string PartsAccessoriesPath = "/Product/PartsAndAccessories";
       }
    }
}
