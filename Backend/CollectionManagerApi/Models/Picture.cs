namespace CollectionManagerApi.Models
{
    public class Picture
    {
        public int PictureID { get; private set; }
        public string RelativePath { get; private set; }
        public string OriginalFileName { get; set; }
        public string ContentType { get; set; }
        public ICollection<Item> Item { get; set; }

    }
}
