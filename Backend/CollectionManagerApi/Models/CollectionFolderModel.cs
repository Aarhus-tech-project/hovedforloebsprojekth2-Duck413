namespace CollectionManagerApi.Models
{
    public class CollectionFolderModel
    {
        public int CollectionFolderID { get; set; }
        public string CollectionFolderName { get; set; }
        public List<CollectionModel> CollectionsInFolder {  get; set; }
    }
}
