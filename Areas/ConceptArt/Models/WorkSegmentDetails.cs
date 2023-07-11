using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hope.BackendServices.API.Areas.ConceptArt.Models
{
    public class WorkSegmentDetails
    {
        public int WorkSegmentId { get; set; }
        public string Name { get; set; }
        public int StatusId { get; set; }
        public int? CreatorId { get; set; }
        public int WorkDivisionId { get; set; }
    }
}
