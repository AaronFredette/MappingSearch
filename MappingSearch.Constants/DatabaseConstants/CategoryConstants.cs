using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MappingSearch.Constants.DatabaseConstants
{
    public static class DatabaseConstants   
    { 
        public  enum CategoryConstants { GEAR, MOTORCYCLES, TRACKS, PARTS, ACCESSORIES }

        public  enum GearSubCategoriesEnum { HELMET, GLOVES, BOOTS, SUIT, JACKET, PANTS, MISC }

        public static List<string> GearSubCategoriesList = new List<string>()
        {
            "Helmet",
            "Gloves",
            "Boots",
            "Suit",
            "Jacket",
            "Pants",
            "Misc"
        };

        public static List<string> MotorcycleSubCategories = new List<string>()
        {
            "Touring",
            "Sport",
            "Dual-sport",
            "Cruiser",
            "Supermoto",
            "Off-road" 
        };

        internal static Dictionary<CategoryConstants,string> CategoryConstantStrings = new Dictionary<CategoryConstants,string>(){
            { CategoryConstants.GEAR,"GEAR"},
            { CategoryConstants.ACCESSORIES,"ACCESSORIES"},
            { CategoryConstants.MOTORCYCLES, "MOTORCYCLES"},
            {CategoryConstants.PARTS,"PARTS"},
            {CategoryConstants.TRACKS,"TRACKS"}};
    }
}
