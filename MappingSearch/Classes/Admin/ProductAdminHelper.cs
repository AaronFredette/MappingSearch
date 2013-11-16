using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MappingSearch.Models.ViewModels;
using MappingSearch.Models.ViewModels.Admin;
using MappingSearch.Models.ViewModels.Product;
using MappingSearch.Models.ViewModels.Tracks;

namespace MappingSearch.Classes.Admin
{
    public class ProductAdminHelper
    {

        internal static AdminApprovalViewModel GetAllUnapprovedProducts()
        {
            List<ProductViewModel> gearList = Data.Accessors.ProductsAccessor.AllUnapprovedGear();
            List<ProductViewModel> motoList = Data.Accessors.ProductsAccessor.AllUnapprovedMotorcycles();

            return new AdminApprovalViewModel() {UnapprovedMotorcycles = motoList, UnapprovedGear = gearList };
        }

        internal static AdminApprovalViewModel GetAllUnapprovedTracks()
        {
            List<Location> locationList = Data.Accessors.TracksAccessor.AllUnapprovedTracks();

            return new AdminApprovalViewModel() { UnapprovedTracks = locationList };
        }
    }
}