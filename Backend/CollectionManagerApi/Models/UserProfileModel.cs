namespace CollectionManagerApi.Models
{
    public class UserProfileModel
    {
        public int UserID { get; private set; }
        public string UserName { get; set; }
        public string? UserDescription { get; set; }
        public int? PictureID { get; set; }
        public PictureModel? Picture { get; set; }
        public bool AdminUserType { get; set; }
        public StatisticModel Statistics { get; private set; } = new();
    }
}
