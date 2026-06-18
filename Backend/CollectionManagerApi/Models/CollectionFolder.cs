namespace CollectionManagerApi.Models
{
    public class CollectionFolder
    {
        public int CollectionFolderID { get; private set; }
        public int UserID { get; private set; }
        public string CollectionFolderName { get; set; }
        public string? CollectionFolderDescription { get; set; }
        public User User { get; set; }
        public ICollection<CollectionFolder_Collection> CollectionFolder_Collection { get; set; }
    }
}
