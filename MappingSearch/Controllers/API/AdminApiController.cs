using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using WebApiContrib.Formatting.Jsonp;

namespace MappingSearch.Controllers.API
{
    public class AdminApiController : MasterController
    {

        //[Authorize]
        [HttpPost]
        public string[] ApproveTracks(string[] approvedIds)
        {

            return approvedIds;
        }

      
    }
}
