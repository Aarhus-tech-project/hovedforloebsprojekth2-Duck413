using CollectionManagerApi.Models;

namespace CollectionManagerApi.DTOs
{
    public class CreateItemDTO
    {
        public string ItemName { get; set; }
        public string? ItemType { get; set; }
        public string? ItemDescription { get; set; }
        public DateTime? ItemPurchaseDate { get; set; }
        public int? PictureID { get; set; }
        public int? ItemCount { get; set; }
        public int? ItemValue { get; set; }
    }
}
