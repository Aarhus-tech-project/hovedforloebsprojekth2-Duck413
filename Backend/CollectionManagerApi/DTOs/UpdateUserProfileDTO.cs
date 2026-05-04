using CollectionManagerApi.Models;

namespace CollectionManagerApi.DTOs
{
    public class UpdateUserProfileDTO
    {
        public string UserName { get; set; }
        public string? UserDescription { get; set; }
        public int? PictureID { get; set; }
    }
}
