using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hope.BackendServices.API.Areas.Fashion.Models
{
    public class ProductSizeDetails
    {
        public int ProductSizeId { get; set; }
        public string ProductSizeName { get; set; }
        public int StatusId { get; set; }
        public int? CreatorId { get; set; }
    }
}
