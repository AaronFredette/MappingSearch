using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MappingSearch.Constants.DatabaseConstants;

namespace MappingSearch.Classes
{
    public static class CurrentCategory
    {
        private static string _currentCategory;
        public static void SetCurrentCategory(string cat)
        {
            _currentCategory = cat;
        }

        public static bool IsMotorcycle()
        {
            return string.Equals(_currentCategory, DatabaseConstants.CategoryConstantStrings[DatabaseConstants.CategoryConstants.MOTORCYCLES], StringComparison.OrdinalIgnoreCase);
        }


        public static bool IsGear() 
        {
            return string.Equals(_currentCategory, DatabaseConstants.CategoryConstantStrings[DatabaseConstants.CategoryConstants.GEAR], StringComparison.OrdinalIgnoreCase);
        }

        public static bool IsAccessory()
        {
            return string.Equals(_currentCategory, DatabaseConstants.CategoryConstantStrings[DatabaseConstants.CategoryConstants.ACCESSORIES],StringComparison.OrdinalIgnoreCase);
        }
    }
}