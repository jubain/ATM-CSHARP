using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hope.BackendServices.API.Areas.Art3D.Models
{
    public class Art3DSystemImageDetails
    {
        public int Art3DSystemImageId { get; set; }
        public int ConceptArtSystemId { get; set; }
        public int TextureTypeId { get; set; }
        public int FileTypeId { get; set; }
        public string ImagePath { get; set; }
        public int StatusId { get; set; }
        public int? CreatorId { get; set; }


    }
}
