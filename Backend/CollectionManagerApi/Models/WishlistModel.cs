namespace CollectionManagerApi.Models
{
    public class WishlistModel
    {
        public int UserID { get; private set; }
        public List<ItemModel> ItemsInWishlist { get; private set; } = new();
    }
}
