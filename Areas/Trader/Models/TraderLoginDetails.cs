using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hope.BackendServices.API.Areas.Trader.Models
{
    public record TraderLoginDetails
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
