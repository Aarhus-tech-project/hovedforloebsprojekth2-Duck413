namespace CollectionManagerApi.Models
{
    public class Wishlist_Item
    {
        public int WishlistID { get; private set; }
        public int ItemID { get; private set; }
        public Wishlist Wishlist { get; set; }
        public Item Item { get; set; }
    }
}
