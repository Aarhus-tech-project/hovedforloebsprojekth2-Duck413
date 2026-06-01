namespace CollectionManagerApi.Models
{
    public class UserProfileModel
    {
        public int UserID { get; private set; }
        public string DisplayName { get; set; }
        public string? UserDescription { get; set; }
        public int? PictureID { get; set; }
        public PictureModel? Picture { get; set; }
        public bool AdminUserType { get; set; }
    }
}
