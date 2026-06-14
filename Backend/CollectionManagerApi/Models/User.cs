namespace CollectionManagerApi.Models
{
    public class User
    {
        public int UserID { get; set; }
        public bool IsActive { get; set; }
        public UserLogin UserLogin { get; set; }
        public UserProfile UserProfile { get; set; }
        public ICollection<Chatroom_User> Chatroom_User { get; set; }
        public ICollection<ShoppingLink> ShoppingLink { get; set; }
        public ICollection<CollectionFolder> CollectionFolder { get; set; }
        public ICollection<Collection> Collection { get; set; }
        public ICollection<Wishlist> Wishlist { get; set; }
        public ICollection<MarketplaceListing> MarketplaceListing { get; set; }
        public ICollection<ChatroomMessage> ChatroomMessage { get; set; }
    }
}
