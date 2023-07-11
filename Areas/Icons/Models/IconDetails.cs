using Hope.BackendServices.API.SharedApiModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hope.BackendServices.API.Areas.Icons.Models
{
    public class IconDetails
    {
        public int IconId { get; set; }
        public string Benefit { get; set; }
        public string ImagePath { get; set; }
        public int ChakraId { get; set; }
        public int StatusId { get; set; }
        public int CreatorId { get; set; }
        //public ChakraDetails Chakra { get; set; }
        //public CreatorDetails Creator { get; set; }
        //public StatusDetails Status { get; set; }
    }
}
