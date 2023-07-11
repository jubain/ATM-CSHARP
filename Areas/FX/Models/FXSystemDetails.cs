using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hope.BackendServices.API.Areas.FX.Models
{
    public class FXSystemDetails
    {
        public int FXSystemId { get; set; }
        public int AssignedToDepartmentId { get; set; }
        public int AnimationApprovalSystemId { get; set; }
    }
}
