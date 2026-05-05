namespace CollectionManagerApi.Models
{
    public class ShoppingLinkModel
    {
        public int ShoppingLinkID { get; private set; }
        public string ShoppingLinkUrl { get; set; }
        public string? ShoppingLinkTitle { get; set; }
        public bool ShoppingLinkIsActive { get; private set; }
    }
}
