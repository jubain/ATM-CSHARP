using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hope.BackendServices.API.Areas.Fashion.Models
{
    public class RangeDetails
    {
        public int RangeId { get; set; }
        public string RangeName { get; set; }
        public int BrandId { get; set; }
        public int StatusId { get; set; }
        public int? CreatorId { get; set; }

    }
}
