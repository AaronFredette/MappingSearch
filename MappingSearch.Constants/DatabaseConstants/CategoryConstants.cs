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

        public  enum GearSubCategories { HELMET, GLOVES, BOOTS, SUIT, JACKET, PANTS, MISC }
        
        internal static Dictionary<CategoryConstants,string> CategoryConstantStrings = new Dictionary<CategoryConstants,string>(){
            { CategoryConstants.GEAR,"GEAR"},
            { CategoryConstants.ACCESSORIES,"ACCESSORIES"},
            { CategoryConstants.MOTORCYCLES, "MOTORCYCLES"},
            {CategoryConstants.PARTS,"PARTS"},
            {CategoryConstants.TRACKS,"TRACKS"}};
    }
}
