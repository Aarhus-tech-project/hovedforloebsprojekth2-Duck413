namespace CollectionManagerApi.Models
{
    public class Chatroom_User
    {
        public int ConversationID { get; private set; }
        public int UserID { get; private set; }
        public Chatroom Chatroom { get; set; }
        public User User { get; set; }

    }
}
