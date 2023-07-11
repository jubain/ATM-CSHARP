using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hope.BackendServices.API.Areas.Animation.Models
{
    public class AnimationToProductLinkPlayBlastDetails
    {
        public int AnimationToProductLinkPlayBlastId { get; set; }
        public int AnimationToProductLinkId { get; set; }
        public string FilePath { get; set; }
    }
}
