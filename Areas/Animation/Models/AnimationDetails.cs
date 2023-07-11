using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Hope.BackendServices.API.Areas.Animation.Models
{
    public class AnimationDetails
    {
        public int AnimationId { get; set; }
        public int? CharacterTextureId { get; set; }
        public int StatusId { get; set; }
        public int? CreatorId { get; set; }
        public string Description { get; set; }
        public int? DepartmentId { get; set; }
        public int? StartIdleId { get; set; }
        public int? EndIdleId { get; set; }
        public int? PlayBlastId { get; set; }
        public int? ConceptArtSystemId { get; set; }

    }
}
