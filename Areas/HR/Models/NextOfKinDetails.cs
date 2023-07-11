using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hope.BackendServices.API.Areas.HR.Models
{
    public class NextOfKinDetails
    {
        public int NextOfKinId { get; set; }

        public string Name { get; set; }

        public string Relationship { get; set; }

        public float AgePercent { get; set; }

        public int StaffId { get; set; }

    }
}
