using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MappingSearch.Models.ViewModels
{
    public class ResponseModel<Type>
    {
        public Type Model { get; set; }
       public  int PageCount { get; set; }
    }
}
