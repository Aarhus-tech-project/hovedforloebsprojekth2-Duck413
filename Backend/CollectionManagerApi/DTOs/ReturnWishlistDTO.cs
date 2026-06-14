using CollectionManagerApi.Models;

namespace CollectionManagerApi.DTOs
{
    public class ReturnWishlistDTO
    {
        public int ItemID { get; private set; }
        public List<Item> ItemsInWishlist { get; private set; } = new();
    }
}
