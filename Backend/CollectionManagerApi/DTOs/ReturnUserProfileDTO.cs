using CollectionManagerApi.Models;

namespace CollectionManagerApi.DTOs
{
    public class ReturnUserProfileDTO
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string? UserDescription { get; set; }
        public string? PictureURL { get; set; }
        public bool AdminUserType { get; set; }
        public ReturnStatisticsDTO Statistics { get; set; }
    }
}
