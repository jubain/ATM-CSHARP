namespace Hope.BackendServices.API.Areas.Animation.Models
{
    public class BodyPartDetails
    {
        public int BodyPartId { get; set; }
        public string Name { get; set; }
        public int StatusId { get; set; }
        public int? CreatorId { get; set; }
    }
}
