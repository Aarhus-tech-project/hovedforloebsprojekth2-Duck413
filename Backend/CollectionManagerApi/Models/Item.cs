namespace CollectionManagerApi.Models
{
    public class Item
    {
        public int ItemID { get; private set; }
        public int? PictureID { get; set; }
        public int? ItemCount { get; set; }
        public int? ItemValue { get; set; }
        public string ItemName { get; set; }
        public string? ItemType { get; set; }
        public string? ItemDescription { get; set; }
        public DateTime? ItemPurchaseDate { get; set; }
        public Picture? Picture { get; set; }
        public ICollection<Item_Collection> Item_Collection { get; set; }
        public ICollection<MarketplaceListing> MarketplaceListing { get; set; }
        public ICollection<Wishlist_Item> Wishlist_Item { get; set; }
    }
}
