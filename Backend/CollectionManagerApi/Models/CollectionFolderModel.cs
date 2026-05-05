namespace CollectionManagerApi.Models
{
    public class CollectionFolderModel
    {
        public int CollectionFolderID { get; private set; }
        public int UserID { get; private set; }
        public string CollectionFolderName { get; set; }
        public string? CollectionFolderDescription { get; set; }
        public List<CollectionModel> CollectionsInFolder { get; private set; } = new();
    }
}
