using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hope.BackendServices.API.Areas.Fashion.Models
{
    public class ProductDesignDetails
    {
        public int ProductDesignId { get; set; }
        public string ProductDesignName { get; set; }
        public int StatusId { get; set; }
        public int? CreatorId { get; set; }


    }
}
