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

        public static readonly List<string> GearSubCategoriesList = new List<string>()
        {
            "Helmet",
            "Gloves",
            "Boots",
            "Suit",
            "Jacket",
            "Pants",
            "Misc"
        };

        public static readonly List<string> MotorcycleSubCategories = new List<string>()
        {
            "Touring",
            "Sport",
            "Dual-sport",
            "Cruiser",
            "Supermoto",
            "Off-road" 
        };

        public  static Dictionary<CategoryConstants,string> CategoryConstantStrings = new Dictionary<CategoryConstants,string>(){
            { CategoryConstants.GEAR,"GEAR"},
            { CategoryConstants.ACCESSORIES,"ACCESSORY"},
            { CategoryConstants.MOTORCYCLES, "MOTORCYCLE"},
            {CategoryConstants.PARTS,"PART"},
            {CategoryConstants.TRACKS,"TRACK"}};
    }
}
