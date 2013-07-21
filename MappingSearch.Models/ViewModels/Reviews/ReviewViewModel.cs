using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MappingSearch.Models.ViewModels.Reviews
{
    public class ReviewViewModel
    {
        public string User { get; set; }
        public string UserMotorcycle { get; set; }
        public int Rating { get; set; }
        public string ReviewText { get; set; }
        public string LengthOfUse { get; set; }
        public int ProductId { get; set; }
        public String PostedDateStr { get; set; }
        public DateTime PostedDate { get; set; }
    }
}
