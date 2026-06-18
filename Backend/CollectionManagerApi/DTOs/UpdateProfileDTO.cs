using CollectionManagerApi.Models;

namespace CollectionManagerApi.DTOs
{
    public class UpdateProfileDTO
    {
        public string DisplayName { get; set; }
        public string? UserDescription { get; set; }
    }
}
