namespace Hope.BackendServices.API.Areas.Animation.Models
{
    public class IdlePoseDetails
    {
        public int IdlePoseId { get; set; }
        public string IdlePoseTitle { get; set; }
        public string IdleFilePath { get; set; }
        public int? CharacterNameId { get; set; }
        public int StatusId { get; set; }
        public int? CreatorId { get; set; }
    }
}
