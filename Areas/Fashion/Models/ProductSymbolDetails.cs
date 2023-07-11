using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hope.BackendServices.API.Areas.Fashion.Models
{
    public class ProductSymbolDetails
    {
        public int ProductSymbolId { get; set; }
        public string ProductSymbolName { get; set; }
        public string ImagePath { get; set; }
        public int StatusId { get; set; }
        public int? CreatorId { get; set; }

    }
}
