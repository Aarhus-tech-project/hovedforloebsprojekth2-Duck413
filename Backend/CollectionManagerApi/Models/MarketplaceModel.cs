namespace CollectionManagerApi.Models
{
    public class MarketplaceModel
    {
        public int ListingID { get; private set; }
        public int ItemID { get; private set; }
        public int UserID { get; private set; }
        public string? DescriptionOfListing { get; set; }
        public DateTime ListingCreatedAt { get; private set; }
        public bool ItemIsRequested { get; set; }
        public bool ListingIsActive { get; set; } = true;
    }
}
