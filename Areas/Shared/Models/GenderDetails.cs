using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hope.BackendServices.API.Areas.Shared.Models
{
    public class GenderDetails
    {
        public int GenderId { get; set; }
        public string GenderName { get; set; }
        public int StatusId { get; set; }
        public int? CreatorId { get; set; }
    }
}
