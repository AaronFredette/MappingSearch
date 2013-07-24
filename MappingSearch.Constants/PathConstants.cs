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
           public static string MotrocycleCategoryPath = "/Product/Category/Motrocycle";
           public static string GearCategoryPath = "/Product/Category/Gear";
           public static string TrackCategoryPath = "/Tracks";
           public static string AccountLoginPath = "/Account/Login";
           public static string AddGearPath = "/Product/AddGear";
       }
    }
}
