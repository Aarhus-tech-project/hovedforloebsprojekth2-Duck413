namespace CollectionManagerApi.Models
{
    public class Wishlist
    {
        public int WishlistID { get; private set; }
        public int UserID { get; private set; }
        public string WishlistName { get; set; }
        public User User {  get; set; }
        public ICollection<Wishlist_Item> Wishlist_Item { get; set; }
    }
}