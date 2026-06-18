namespace CollectionManagerApi.Models
{
    public class CollectionFolder_Collection
    {
        public int CollectionFolderID { get; private set; }
        public int CollectionID { get; private set; }
        public CollectionFolder CollectionFolder { get; set; }
        public Collection Collection { get; set; }
    }
}
