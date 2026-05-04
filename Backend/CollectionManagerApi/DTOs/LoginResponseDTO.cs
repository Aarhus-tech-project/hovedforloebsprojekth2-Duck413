namespace CollectionManagerApi.DTOs
{
    public class LoginResponseDTO
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string? PictureUrl { get; set; }
        public bool AdminUserType { get; set; }
    }
}
