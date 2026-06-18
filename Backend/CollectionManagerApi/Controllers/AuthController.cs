using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CollectionManagerApi.Models;
using CollectionManagerApi.DTOs;
using CollectionManagerApi.Data;

namespace CollectionManagerApi.Controllers

    /*NOTE: jeg startede med at skrive alt logic i én fil, og så splittede jeg det senere op i controller og service. 
     Grundet tidspres nåede jeg det ikke med denne fil, men noget af den burde flyttes til en service*/
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly IConfiguration _config;

        public AuthController(MyDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(CreateUserDTO dto)
        {
            bool emailTaken = _context.UserLogin.Any(u => u.UserEmail == dto.UserEmail);
            if (emailTaken)
                return BadRequest("Email is already in use.");

            var user = new User { IsActive = true };
            _context.User.Add(user);
            await _context.SaveChangesAsync();

            var userLogin = new UserLogin
            {
                UserID = user.UserID,
                UserEmail = dto.UserEmail,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password)
            };
            _context.UserLogin.Add(userLogin);

            var userProfile = new UserProfile
            {
                UserID = user.UserID,
                DisplayName = dto.DisplayName,
                UserDescription = dto.UserDescription,
                AdminUserType = false
            };
            _context.UserProfile.Add(userProfile);

            var wishlist = new Wishlist(user.UserID, "My Wishlist");
            _context.Wishlist.Add(wishlist);

            await _context.SaveChangesAsync();

            return Ok("User registered successfully.");
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDTO dto)
        {
            var userLogin = _context.UserLogin
                .FirstOrDefault(u => u.UserEmail == dto.UserEmail);

            if (userLogin == null)
                return Unauthorized("Invalid email or password.");

            bool passwordValid = BCrypt.Net.BCrypt.Verify(dto.Password, userLogin.PasswordHash);
            if (!passwordValid)
                return Unauthorized("Invalid email or password.");

            var userProfile = _context.UserProfile
                .FirstOrDefault(p => p.UserID == userLogin.UserID);

            var token = GenerateToken(userLogin, userProfile?.DisplayName ?? "Unknown");

            return Ok(new { token });
        }

        private string GenerateToken(UserLogin userLogin, string displayName)
        {
            var jwtSettings = _config.GetSection("JwtSettings");

            var claims = new[]
            {
                new Claim("userId", userLogin.UserID.ToString()),
                new Claim("email", userLogin.UserEmail),
                new Claim("displayName", displayName)
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(
                    double.Parse(jwtSettings["ExpiryMinutes"])),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}