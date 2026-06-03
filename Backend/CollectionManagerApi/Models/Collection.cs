namespace CollectionManagerApi.Models
{
    public class Collection
    {
        public int CollectionId { get; private set; }
        public int UserID { get; private set; }
        public string CollectionName { get; set; }
        public string? CollectionDescription { get; set; }
        public User User { get; set; }
        public ICollection<CollectionFolder_Collection> CollectionFolder_Collection { get; set; }
        public ICollection<Item_Collection> Item_Collection { get; set; }


    }
}
