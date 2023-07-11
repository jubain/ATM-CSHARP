using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hope.BackendServices.API.Areas.FX.Models
{
    public class FXFileDetails
    {
        public int FXFileId { get; set; }
        public string Name { get; set; }
        public string FilePath { get; set; }
        public int FXSystemId { get; set; }

    }
}
