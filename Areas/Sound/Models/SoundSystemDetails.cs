using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hope.BackendServices.API.Areas.Sound.Models
{
    public class SoundSystemDetails
    {
        public int SoundSystemId { get; set; }
        public int AssignedToDepartmentId { get; set; }
        public int AnimationApprovalSystemId { get; set; }

    }
}
