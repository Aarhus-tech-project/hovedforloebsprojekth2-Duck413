namespace CollectionManagerApi.Models
{
    public class Wishlist_Item
    {
        public int WishlistID { get; set; }
        public int ItemID { get; set; }
        public Wishlist Wishlist { get; set; }
        public Item Item { get; set; }
    }
}
