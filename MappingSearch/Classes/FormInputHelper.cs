using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace MappingSearch.Classes
{
    public static class FormInputHelper
    {
        public static string StripInput(string input)
        {
            if (input == null) return String.Empty;
            return Regex.Replace(input, @"[\r\n\x00\x1a\\'""]", @"\$0");
        }
    }
}