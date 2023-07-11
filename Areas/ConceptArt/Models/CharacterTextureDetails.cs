namespace Hope.BackendServices.API.Areas.Animation.Models
{
    public class CharacterTextureDetails
    {
        public int CharacterTextureId { get; set; }
        public int CharacterNameId { get; set; }
        public int TextureTypeId { get; set; }
        public int StatusId { get; set; }
        public int? CreatorId { get; set; }
    }
}
