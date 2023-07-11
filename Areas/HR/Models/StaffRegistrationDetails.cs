using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hope.BackendServices.API.Areas.HR.Models
{
    public class StaffRegistrationDetails : StaffDetails
    {
        public string Password { get; set; }
    }
}
