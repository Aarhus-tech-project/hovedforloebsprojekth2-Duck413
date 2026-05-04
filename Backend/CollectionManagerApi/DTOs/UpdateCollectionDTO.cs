using CollectionManagerApi.Models;

namespace CollectionManagerApi.DTOs
{
    public class UpdateCollectionDTO
    {
        public string CollectionName { get; set; }
        public string? CollectionDescription { get; set; }
    }
}
