namespace CollectionManagerApi.Models
{
    public class Item_Collection
    {
        public int ItemID { get; private set; }
        public int CollectionID { get; private set; }
        public Item Item { get; set; }
        public Collection Collection { get; set; }
    }
}
