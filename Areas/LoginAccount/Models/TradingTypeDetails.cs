using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hope.BackendServices.API.Areas.LoginAccount.Models
{
    public class TradingTypeDetails
    {
        public int TradingTypeId { get; set; }
        public string Name { get; set; }
        public int StatusId { get; set; }
        public int? CreatorId { get; set; }

    }
}
