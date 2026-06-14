namespace CollectionManagerApi.Models
{
    public class UserLogin
    {
        public int UserID { get; set; }
        public string UserEmail { get; set; }
        public string PasswordHash { get; set; }
        public User User { get; set; }
    }
}
