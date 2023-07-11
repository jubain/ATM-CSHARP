using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hope.BackendServices.API.Areas.Shared.Models
{
    public class AnimationApprovalSystemDetails
    {
        public int AnimationApprovalSystemId { get; set; }
        public string CharacterName { get; set; }
        public string AnimationDescription { get; set; }
        public string FbxFileName { get; set; }
        public string FilePath { get; set; }
        public int StatusId { get; set; }
        public int? CreatorId { get; set; }
    }
}
