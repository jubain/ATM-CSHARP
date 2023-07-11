using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hope.BackendServices.API.Areas.FX.Models
{
    public class FXSystemPlayblastDetails
    {
        public int FXSystemPlayblastId { get; set; }
        public string FilePath { get; set; }
        public int FXSystemId { get; set; }
        public int StatusId { get; set; }
        public int? CreatorId { get; set; }
    }
}
