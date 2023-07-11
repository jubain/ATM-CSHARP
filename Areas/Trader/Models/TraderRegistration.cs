using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hope.BackendServices.API.Areas.Trader.Models
{
    public record TraderRegistration
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string TradingName { get; set; }
        public string TradingEntityTypeCode { get; set; }
        public string CountryCode { get; set; }
        public string RegionCode { get; set; }
        public string ContactName { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }
    }
}
