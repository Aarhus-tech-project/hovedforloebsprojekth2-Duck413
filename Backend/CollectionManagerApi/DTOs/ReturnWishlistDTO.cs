using CollectionManagerApi.Models;

namespace CollectionManagerApi.DTOs
{
    public class ReturnWishlistDTO
    {
        public int ItemID { get; private set; }
        public List<ItemModel> ItemsInWishlist { get; private set; } = new();
    }
}
