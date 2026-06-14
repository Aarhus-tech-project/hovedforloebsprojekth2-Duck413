namespace CollectionManagerApi.Models
{
    public class Item_Collection
    {
        public int ItemID { get; set; }
        public int CollectionID { get; set; }
        public Item Item { get; set; }
        public Collection Collection { get; set; }
    }
}
