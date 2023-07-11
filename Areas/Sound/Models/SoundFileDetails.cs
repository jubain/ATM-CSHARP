using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hope.BackendServices.API.Areas.Sound.Models
{
    public class SoundFileDetails
    {
        public int SoundFileId { get; set; }
        public string Name { get; set; }
        public string FilePath { get; set; }
        public int SoundSystemId { get; set; }
    }
}
