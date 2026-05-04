namespace CollectionManagerApi.Models
{
    public class ChatroomModel
    {
        public int ConversationID { get; private set; }
        public int ConversationUser1ID { get; private set; }
        public int ConversationUser2ID { get; private set; }
        public int? ListingID { get; private set; }
        public List<ChatroomMessageModel> MessagesInConversation { get; private set; } = new();
    }
}
