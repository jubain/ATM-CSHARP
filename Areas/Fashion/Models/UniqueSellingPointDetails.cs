using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hope.BackendServices.API.Areas.Fashion.Models
{
    public class UniqueSellingPointDetails
    {
        public int UniqueSellingPointId { get; set; }
        public string UniqueSellingPointName { get; set; }
        public string ImagePath { get; set; }
        public int StatusId { get; set; }
        public int? CreatorId { get; set; }

    }
}
