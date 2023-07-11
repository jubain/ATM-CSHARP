using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hope.BackendServices.API.Areas.Sound.Models
{
    public class SoundSystemPlayblastDetails
    {
        public int SoundSystemPlayblastId { get; set; }
        public string FilePath { get; set; }
        public int SoundSystemId { get; set; }
        public int StatusId { get; set; }
        public int? CreatorId { get; set; }
    }
}
