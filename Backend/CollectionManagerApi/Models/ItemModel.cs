namespace CollectionManagerApi.Models
{
    public class ItemModel
    {
        public int ItemID { get; private set; }
        public string ItemName { get; set; }
        public string? ItemType { get; set; }
        public string? ItemDescription { get; set; }
        public DateTime? ItemPurchaseDate { get; set; }
        public int? PictureID { get; set; }
        public PictureModel? Picture { get; set; }
        public int? ItemCount { get; set; }
        public int? ItemValue { get; set; }
    }
}
