namespace Hope.BackendServices.API.Areas.Animation.Models
{
    public class AnimationExpressionDetails
    {
        public int AnimationExpressionId { get; set; }
        public string Expression { get; set; }
        public string KeyWords { get; set; }
        public string AnimationExpressionFilePath { get; set; }
        public int BodyPartId { get; set; }
        public int CharacterNameId { get; set; }
        public int StatusId { get; set; }
        public int? CreatorId { get; set; }
    }
}
