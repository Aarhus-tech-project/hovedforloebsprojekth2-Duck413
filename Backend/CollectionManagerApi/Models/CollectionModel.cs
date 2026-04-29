namespace CollectionManagerApi.Models
{
    public class CollectionModel
    {
        public int Id { get; set; }
        public string CollectionName { get; set; }
        public List<ItemModel> ItemsInCollection { get; set; }
    }
}
