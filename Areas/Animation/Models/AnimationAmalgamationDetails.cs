using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hope.BackendServices.API.Areas.Animation.Models
{
    public class AnimationAmalgamationDetails
    {
        public int AnimationAmalgamationId { get; set; }
        public int? BrandId { get; set; }
        public int? RangeId { get; set; }
        public int? ProductDesignId { get; set; }
        public int? ProductTypeId { get; set; }
        public int? CharacterNameId { get; set; }
        public string Description { get; set; }
        public int StatusId { get; set; }
        public int? CreatorId { get; set; }

    }
}
