namespace CollectionManagerApi.DTOs
{
    public class CreateUserDTO
    {
        public string UserEmail { get; set; }
        public string Password { get; set; }
        public string DisplayName { get; set; }
        public string? UserDescription { get; set; }

        //public int? PictureID { get; set; }
    }
}
