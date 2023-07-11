using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hope.BackendServices.API.Areas.Fashion.Models
{
    public class ProductTypeDetails
    {
        public int ProductTypeId { get; set; }
        public string ProductTypeName { get; set; }
        public int ProductGroupId { get; set; }
        public int StatusId { get; set; }
        public int? CreatorId { get; set; }
    }
}
