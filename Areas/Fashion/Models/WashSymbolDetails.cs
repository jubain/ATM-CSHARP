using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hope.BackendServices.API.Areas.Fashion.Models
{
    public class WashSymbolDetails
    {
        public int WashSymbolId { get; set; }
        public string WashSymbolName { get; set; }
        public string ImagePath { get; set; }
        public int StatusId { get; set; }
        public int? CreatorId { get; set; }

    }
}
