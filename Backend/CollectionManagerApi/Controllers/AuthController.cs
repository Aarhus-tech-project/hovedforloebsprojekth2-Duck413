using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CollectionManagerApi.Models;
using CollectionManagerApi.DTOs;
using CollectionManagerApi.Data;

namespace CollectionManagerApi.Controllers
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

        // POST api/auth/register
        [HttpPost("register")]
        public async Task<IActionResult> Register(CreateUserDTO dto)
        {
            // Check if email already exists
            bool emailTaken = _context.UserLogin.Any(u => u.UserEmail == dto.UserEmail);
            if (emailTaken)
                return BadRequest("Email is already in use.");

            // Create the root User
            var user = new User { IsActive = true };
            _context.User.Add(user);
            await _context.SaveChangesAsync(); // Save so user gets its UserId

            // Create UserLogin with hashed password
            var userLogin = new UserLogin
            {
                UserID = user.UserID,
                UserEmail = dto.UserEmail,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password)
            };
            _context.UserLogin.Add(userLogin);

            // Create UserProfile
            var userProfile = new UserProfile
            {
                UserID = user.UserID,
                DisplayName = dto.DisplayName,
                AdminUserType = false
            };
            _context.UserProfile.Add(userProfile);

            await _context.SaveChangesAsync();

            return Ok("User registered successfully.");
        }

        // POST api/auth/login
        [HttpPost("login")]
        public IActionResult Login(LoginDTO dto)
        {
            // Find user by email
            var userLogin = _context.UserLogin
                .FirstOrDefault(u => u.UserEmail == dto.UserEmail);

            if (userLogin == null)
                return Unauthorized("Invalid email or password.");

            // Verify password
            bool passwordValid = BCrypt.Net.BCrypt.Verify(dto.Password, userLogin.PasswordHash);
            if (!passwordValid)
                return Unauthorized("Invalid email or password.");

            // Generate JWT token
            var token = GenerateToken(userLogin);

            return Ok(new { token });
        }

        private string GenerateToken(UserLogin userLogin)
        {
            var jwtSettings = _config.GetSection("JwtSettings");

            var claims = new[]
            {
            new Claim("userId", userLogin.UserID.ToString()),
            new Claim("email", userLogin.UserEmail)
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