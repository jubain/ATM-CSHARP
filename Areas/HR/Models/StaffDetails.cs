using Hope.BackendServices.API.Shared.JsonConverters;
using Hope.BackendServices.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Hope.BackendServices.API.Areas.HR.Models
{
    public class StaffDetails
    {
        public int StaffId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        [JsonConverter(typeof(DateOnlyConverter))]
        public DateTime DateOfBirth { get; set; }
        public int? CountryId { get; set; }
        public int? DepartmentId { get; set; }
        public int? JobTitleId { get; set; }
        public int? HierarchyId { get; set; }
        public int? ContactCountryCodeId { get; set; }
        public int? EmergencyContactCountryCodeId { get; set; }
        public int? StaffStatusId { get; set; }
        public int? RoomId { get; set; }

        [JsonConverter(typeof(ClockFormatConverter))]
        public TimeSpan KeyAccessStartTime { get; set; }
        [JsonConverter(typeof(ClockFormatConverter))]
        public TimeSpan KeyAccessEndTime { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string Postcode { get; set; }
        [JsonConverter(typeof(DateOnlyConverter))]
        public DateTime StartDate { get; set; }
        [JsonConverter(typeof(DateOnlyConverter))]
        public DateTime EndDate { get; set; }
        public string ContactNumber { get; set; }
        public string EmergencyContactName { get; set; }
        public string EmergencyContactTelephoneNumber { get; set; }
        public string EmergencyContactRelationship { get; set; }

       

    }
}
