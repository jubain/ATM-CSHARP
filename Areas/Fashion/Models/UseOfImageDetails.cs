using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hope.BackendServices.API.Areas.Fashion.Models
{
    public class UseOfImageDetails
    {
        public int UseOfImageId { get; set; }
        public string UseOfImageName { get; set; }
        public int StatusId { get; set; }
        public int? CreatorId { get; set; }
    }
}
