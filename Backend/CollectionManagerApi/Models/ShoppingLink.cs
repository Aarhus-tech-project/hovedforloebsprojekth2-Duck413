namespace CollectionManagerApi.Models
{
    public class ShoppingLink
    {
        public int ShoppingLinkID { get; private set; }
        public int UserID { get; private set; }
        public string ShoppingLinkUrl { get; set; }
        public string? ShoppingLinkTitle { get; set; }
        public bool ShoppingLinkIsActive { get; private set; }
        public User User { get; set; }
    }
}
