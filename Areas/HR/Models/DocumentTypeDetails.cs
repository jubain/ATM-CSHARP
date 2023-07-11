using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hope.BackendServices.API.Areas.HR.Models
{
    public class DocumentTypeDetails
    {
        public int DocumentTypeId { get; set; }
        public string Type { get; set; }
        public int StatusId { get; set; }
        public int? CreatorId { get; set; }

    }
}
