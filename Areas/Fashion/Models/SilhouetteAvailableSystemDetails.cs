using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hope.BackendServices.API.Areas.Fashion.Models
{
    public class SilhouetteAvailableSystemDetails
    {
        public int SilhouetteAvailableSystemId { get; set; }
        public string ProductType { get; set; }
        public string ProductColour { get; set; }
        public int ProductSizeId { get; set; }
        public int GenderId { get; set; }
        public int ProductReferenceImageId { get; set; }
        public int? ColourAvailableSystemId { get; set; }
        public int StatusId { get; set; }
        public int? CreatorId { get; set; }

    }
}
