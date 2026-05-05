namespace CollectionManagerApi.Models
{
    public class UserLoginModel
    {
        public int UserID { get; private set; }
        public string UserEmail { get; set; }
        public string PasswordHash { get; set; }
    }
}
