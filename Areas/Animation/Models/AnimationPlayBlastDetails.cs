namespace Hope.BackendServices.API.Areas.Animation.Models
{
    public class AnimationPlayBlastDetails
    {
        public int AnimationPlayBlastId { get; set; }
        public string PlayBlastFilePath { get; set; }
        public string FBXFilePath { get; set; }
        public string MayaFilePath { get; set; }
        public int? CharacterNameId { get; set; }
        public int StatusId { get; set; }
        public int? CreatorId { get; set; }
    }
}
