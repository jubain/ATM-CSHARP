using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hope.BackendServices.API.Areas.HR.Models
{
    public class StaffDocumentDetails
    {
        public int StaffDocumentId { get; set; }
        public int StaffId { get; set; }

        public int DocumentTypeId { get; set; }

        public string ImagePath { get; set; }

                
    }
}
