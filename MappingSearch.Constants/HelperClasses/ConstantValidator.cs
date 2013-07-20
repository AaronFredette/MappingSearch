using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MappingSearch.Constants.HelperClasses
{
    public static class ConstantValidator
    {
        public static bool IsValidCategory(string category)
        {
            return DatabaseConstants.DatabaseConstants.CategoryConstantStrings.ContainsValue(category.ToUpper()); 
        }
    }
}
