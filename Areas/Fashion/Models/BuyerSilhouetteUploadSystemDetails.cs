using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hope.BackendServices.API.Areas.Fashion.Models
{
    public class BuyerSilhouetteUploadSystemDetails
    {
        public int BuyerSilhouetteUploadSystemId { get; set; }
        public int ProductTypeId { get; set; }
        public int ProductSizeId { get; set; }
        public int GenderId { get; set; }
        public int ColourId { get; set; }

    }
}
