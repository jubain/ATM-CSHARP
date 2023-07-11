using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hope.BackendServices.API.Areas.Fashion.Models
{
    public class ProductGroupDetails
    {
        public int ProductGroupId { get; set; }
        public string ProductGroupName { get; set; }
        public int StatusId { get; set; }
        public int? CreatorId { get; set; }

    }
}
