using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hope.BackendServices.API.Areas.Fashion.Models
{
    public class ProductCreationDetails
    {
        public int ProductCreationId { get; set; }
        public int PrimaryColourId { get; set; }
        public int SecondaryColourId { get; set; }
        public int UseOfImageId { get; set; }
        public int FileTypeId { get; set; }
        public string ImagePath { get; set; }
        public int? SilhouetteAvailableSystemId { get; set; }
        public int StatusId { get; set; }
        public int? CreatorId { get; set; }


    }
}
