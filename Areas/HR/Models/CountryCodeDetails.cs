using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hope.BackendServices.API.Areas.HR.Models
{
    public class CountryCodeDetails
    {
        public int CountryCodeId { get; set; }

        public string Code { get; set; }

        public int StatusId { get; set; }
        public int? CreatorId { get; set; }
    }
}
