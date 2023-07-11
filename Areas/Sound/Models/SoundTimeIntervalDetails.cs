using Hope.BackendServices.API.Shared.JsonConverters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Hope.BackendServices.API.Areas.Sound.Models
{
    public class SoundTimeIntervalDetails
    {
        public int SoundTimeIntervalId { get; set; }

        [JsonConverter(typeof(TimeOnlyConverter))]
        public TimeSpan StartTime { get; set; }
        [JsonConverter(typeof(TimeOnlyConverter))]
        public TimeSpan EndTime { get; set; }
        public int SoundFileId { get; set; }
    }
}
