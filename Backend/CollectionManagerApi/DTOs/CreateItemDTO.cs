using System.ComponentModel.DataAnnotations;

namespace CollectionManagerApi.DTOs
{
    public class CreateItemDTO
    {
        public int? CollectionID { get; set; }
        public int? WishlistID { get; set; }
        public string ItemName { get; set; }
        public int? ItemCount { get; set; }
        public int? ItemValue { get; set; }
        public string? ItemType { get; set; }
        public string? ItemDescription { get; set; }
        public int? PictureID { get; set; }
        public DateTime? ItemPurchaseDate { get; set; }
    }
}