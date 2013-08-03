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

    #region gearConstants
        private static List<string> _gearSubCategoriesList;

        public static  List<string> GearSubCategoriesList
        {
            get 
            {
                if (_gearSubCategoriesList == null)
                {
                    _gearSubCategoriesList = new List<string>()
                    {
                        "Helmet",
                        "Gloves",
                        "Boots",
                        "Suit",
                        "Jacket",
                        "Pants",
                        "Misc"
                    };
                }
                return _gearSubCategoriesList; 
            }
        }
    #endregion 

    #region Motorcycle constants


        private static List<string> _motorcycleEngineTypes;

        public static List<string> MotorcycleEngineTypes
        {
            get
            {
                if (_motorcycleEngineTypes == null)
                {
                    _motorcycleEngineTypes = new List<string>()
                    {
                        "Aircooled Single 4 stroke",
                        "Aircooled Single 2 stroke",
                        "Aircooled Parallel Twin 2 Stroke",
                        "Aircooled 45 degree V Twin 4 Stroke",
                        "Aircooled 90 degree L Twin 4 Stroke (Desmo valves)",
                        "Liquid Cooled 90 degree L Twin 4 Stroke (Desmo valves)",
                        "Liquid cooled Inline 4",
                        "Liquid cooled Inline 6"
                    };
                }
                return _motorcycleEngineTypes;
            }

        }

        private static List<string> _motorcycleSubcategories;

        public static  List<string> MotorcycleSubCategories
        {
            get
            {
                if (_motorcycleSubcategories == null)
                {
                    _motorcycleSubcategories = new List<string>()
                    {
                        "Touring",
                        "Sport",
                        "Dual-sport",
                        "Cruiser",
                        "Supermoto",
                        "Off-road" 
                    };
                }
                return _motorcycleSubcategories;
            }
        }
    #endregion 

        private  static Dictionary<CategoryConstants,string> _categoryConstantStrings;
        
        public static Dictionary<CategoryConstants, string> CategoryConstantStrings
        {
            get 
            {
                if (_categoryConstantStrings == null) {
                    _categoryConstantStrings = new Dictionary<CategoryConstants, string>(){
                    { CategoryConstants.GEAR,"GEAR"},
                    { CategoryConstants.ACCESSORIES,"ACCESSORY"},
                    { CategoryConstants.MOTORCYCLES, "MOTORCYCLE"},
                    {CategoryConstants.PARTS,"PART"},
                    {CategoryConstants.TRACKS,"TRACK"}};
                }
                return _categoryConstantStrings; 
            }
        }
    }
}
