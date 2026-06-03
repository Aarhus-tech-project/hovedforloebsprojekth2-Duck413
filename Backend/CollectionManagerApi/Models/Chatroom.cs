namespace CollectionManagerApi.Models
{
    public class Chatroom
    {
        public int ConversationID { get; private set; }
        public int? ListingID { get; private set; }
        public int ConversationUser1ID { get; private set; }
        public int ConversationUser2ID { get; private set; }
        public MarketplaceListing MarketplaceListing { get; set; }
        public ICollection<ChatroomMessage> ChatroomMessage { get; set; }
        public ICollection<Chatroom_User> Chatroom_User { get; set; }
    }
}
