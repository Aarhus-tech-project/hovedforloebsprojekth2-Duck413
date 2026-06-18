namespace CollectionManagerApi.Models
{
    public class MarketplaceListing
    {
        public int ListingID { get; private set; }
        public int ItemID { get; private set; }
        public int UserID { get; private set; }
        public string? DescriptionOfListing { get; set; }
        public bool ItemIsRequested { get; set; }
        public bool ListingIsActive { get; set; } = true;
        public DateTime ListingCreatedAt { get; private set; }
        public Item Item { get; set; }
        public User User { get; set; }
        public ICollection<Chatroom> Chatroom { get; set; }

    }
}
