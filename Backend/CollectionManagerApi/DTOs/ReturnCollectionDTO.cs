using CollectionManagerApi.Models;

namespace CollectionManagerApi.DTOs
{
    public class ReturnCollectionDTO
    {
        public int CollectionId { get; private set; }
        public string CollectionName { get; set; }
        public string? CollectionDescription { get; set; }
        public List<ReturnItemDTO> ItemsInCollection { get; private set; } = new();
    }
}
