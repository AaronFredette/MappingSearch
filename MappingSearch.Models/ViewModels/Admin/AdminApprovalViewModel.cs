using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MappingSearch.Models.ViewModels.Admin
{
    public class AdminApprovalViewModel
    {
        public List<Models.ViewModels.Product.ProductViewModel> UnapprovedGear { get; set; }
        public List<Models.ViewModels.Product.ProductViewModel> UnapprovedMotorcycles { get; set; }
    }
}
