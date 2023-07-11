using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hope.BackendServices.API.Areas.Fashion.Models
{
    public class BuyerBrandRangeCombinationDetails
    {
        public int BuyerBrandRangeCombinationId { get; set; }
        public int BrandId { get; set; }
        public int RangeId { get; set; }
        public int ProductDesignId { get; set; }
        public int UniqueSellingPointId { get; set; }
        public int ProductsymbolId { get; set; }
        public int WashSymbolId { get; set; }
        public int StatusId { get; set; }
        public int? CreatorId { get; set; }

    }
}
