using Hope.BackendServices.API.SharedApiModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hope.BackendServices.API.Areas.Icons.Models
{
    public class ColourDetails
    {
        public int ColourId { get; set; }
        public string Name { get; set; }
        public int StatusId { get; set; }
        public int CreatorId { get; set; }
        //public CreatorDetails Creator { get; set; }
        //public StatusDetails Status { get; set; }

    }
}
