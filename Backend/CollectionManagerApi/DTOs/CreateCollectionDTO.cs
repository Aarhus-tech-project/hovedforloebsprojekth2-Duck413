using CollectionManagerApi.Models;

namespace CollectionManagerApi.DTOs
{
    public class CreateCollectionDTO
    {
        public string CollectionName { get; set; }
        public string? CollectionDescription { get; set; }
    }
}
