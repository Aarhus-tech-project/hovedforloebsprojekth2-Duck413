namespace CollectionManagerApi.DTOs
{
    public class LoginRequestDTO
    {
        public string UserEmail { get; set; }
        public string PasswordHash { get; set; }
    }
}
