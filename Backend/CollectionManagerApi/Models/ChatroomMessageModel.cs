namespace CollectionManagerApi.Models
{
    public class ChatroomMessageModel
    {
        public int MessageID { get; private set; }
        public int UserID { get; private set; }
        public int ConversationID { get; private set; }
        public string? MessageText { get; set; }
        public DateTime MessageSentAt { get; private set; }
    }
}
