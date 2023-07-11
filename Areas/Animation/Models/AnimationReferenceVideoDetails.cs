namespace Hope.BackendServices.API.Areas.Animation.Models
{
    public class AnimationReferenceVideoDetails
    {
        public int AnimationReferenceVideoId { get; set; }
        public string AnimationReferenceVideoFilePath { get; set; }
        public int? CharacterNameId { get; set; }
        public int StatusId { get; set; }
        public int? CreatorId { get; set; }
    }
}
