using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hope.BackendServices.API.Areas.HR.Models
{
    public class HRHiringSourceDetails
    {
        public int HRHiringSourceId { get; set; }
        public string Name { get; set; }
        public int StatusId { get; set; }
        public int? CreatorId { get; set; }

    }
}
