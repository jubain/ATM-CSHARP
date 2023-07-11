using Hope.BackendServices.API.Shared.JsonConverters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Hope.BackendServices.API.Areas.ConceptArt.Models
{
    public class ConceptArtSystemDetails
    {
        public int ConceptArtSystemId { get; set; }
        public string Title { get; set; }
        public int? WorkDivisionId { get; set; }
        public int? WorkSegmentId { get; set; }
        public int? ArtAssetId { get; set; }
        public int? AssignedToId { get; set; }
        public DateTime SetupTime { get ; set ; }
        public int? ImportanceId { get; set; }
        public int? CharacterNameId { get; set; }
        public string Requirement { get; set; }
        public int StatusId { get; set; }
        public int? CreatorId { get; set; }

    }
}
