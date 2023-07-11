using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hope.BackendServices.API.Areas.Fashion.Models
{
    public class ColourAvailableSystemDetails
    {        
            public int ColourAvailableSystemId { get; set; }
            public string Brand { get; set; }
            public string Range { get; set; }
            public string Design { get; set; }
            public int StatusId { get; set; }
            public int? CreatorId { get; set; }

    }
}
