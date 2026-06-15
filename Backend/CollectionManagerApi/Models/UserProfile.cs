namespace CollectionManagerApi.Models
{
    public class UserProfile
    {
        public int UserID { get; set; }
        public int? PictureID { get; set; }
        public string DisplayName { get; set; }
        public string? UserDescription { get; set; }
        public bool AdminUserType { get; set; }
        public Picture? Picture { get; set; }
        public User User { get; set; }
    }
}
