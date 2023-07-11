using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hope.BackendServices.API.Areas.ConceptArt.Models
{
    public class ArtAssetDetails
    {
        public int ArtAssetId { get; set; }
        public string Name { get; set; }
        public int StatusId { get; set; }
        public int? CreatorId { get; set; }

    }
}
