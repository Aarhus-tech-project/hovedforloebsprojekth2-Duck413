namespace CollectionManagerApi.Models
{
    public class CollectionModel
    {
        public int CollectionId { get; private set; }
        public int UserID { get; private set; }
        public string CollectionName { get; set; }
        public string? CollectionDescription { get; set; }
        public List<ItemModel> ItemsInCollection { get; private set; } = new();
    }
}
