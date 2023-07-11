using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hope.BackendServices.API.Areas.ConceptArt.Models
{
    public class ConceptArtSystemImageDetails
    {
        public int ConceptArtSystemImageId { get; set; }
        public int ConceptArtSystemId { get; set; }
        
        public int? AssignTo { get; set; }
        public string ImagePath { get; set; }
        public int StatusId { get; set; }
        public int? CreatorId { get; set; }

    }
}
