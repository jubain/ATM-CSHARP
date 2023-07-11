using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hope.BackendServices.API.Areas.Fashion.Models
{
    public class BrandDetails
    {
        public int BrandId { get; set; }
        public string Name { get; set; }
        public string CharitableInitiative { get; set; }
        public int StatusId { get; set; }
        public int? CreatorId { get; set; }

    }
}
