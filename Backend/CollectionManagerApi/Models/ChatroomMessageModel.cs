namespace CollectionManagerApi.Models
{
    public class ChatroomMessageModel
    {
        public int MessageID { get; private set; }
        public int MessageSenderID { get; private set; }
        public string? MessageText { get; set; }
        public DateTime MessageSentAt { get; private set; }
    }
}
