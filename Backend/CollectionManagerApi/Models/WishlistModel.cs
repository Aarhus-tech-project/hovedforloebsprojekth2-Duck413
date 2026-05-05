namespace CollectionManagerApi.Models
{
    public class WishlistModel
    {
        public int WishlistID { get; private set; }
        public int ItemID { get; private set; }
        public int UserID { get; private set; }
        public List<ItemModel> ItemsInWishlist { get; private set; } = new();
    }
}
