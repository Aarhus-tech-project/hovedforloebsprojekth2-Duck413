using CollectionManagerApi.Data;
using CollectionManagerApi.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace CollectionManagerApi.Controllers

/*NOTE: jeg startede med at skrive alt logic i én fil, og så splittede jeg det senere op i controller og service. 
Grundet tidspres nåede jeg det ikke med denne fil, men noget af den burde flyttes til en service*/
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MyDbContext _context;

        public UserController(MyDbContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet("me")]
        public async Task<IActionResult> GetMyProfile()
        {
            var userIdClaim = User.FindFirst("userId")?.Value;
            if (userIdClaim == null) return Unauthorized();
            int userId = int.Parse(userIdClaim);

            var profile = await _context.UserProfile
                .FirstOrDefaultAsync(p => p.UserID == userId);

            if (profile == null) return NotFound("Profile not found.");

            return Ok(new
            {
                displayName = profile.DisplayName,
                userDescription = profile.UserDescription
            });
        }

        [Authorize]
        [HttpPut("me")]
        public async Task<IActionResult> UpdateMyProfile(UpdateProfileDTO dto)
        {
            var userIdClaim = User.FindFirst("userId")?.Value;
            if (userIdClaim == null) return Unauthorized();
            int userId = int.Parse(userIdClaim);

            var profile = await _context.UserProfile
                .FirstOrDefaultAsync(p => p.UserID == userId);

            if (profile == null) return NotFound("Profile not found.");

            profile.DisplayName = dto.DisplayName;
            profile.UserDescription = dto.UserDescription;

            await _context.SaveChangesAsync();

            return Ok("Profile updated successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.User
                .Include(u => u.UserProfile)
                .Include(u => u.UserLogin)
                .Include(u => u.Collection)
                    .ThenInclude(c => c.CollectionFolder_Collection)
                .Include(u => u.Collection)
                    .ThenInclude(c => c.Item_Collection)
                        .ThenInclude(ic => ic.Item)
                            .ThenInclude(i => i.Wishlist_Item)
                .Include(u => u.Collection)
                    .ThenInclude(c => c.Item_Collection)
                        .ThenInclude(ic => ic.Item)
                            .ThenInclude(i => i.MarketplaceListing)
                                .ThenInclude(ml => ml.Chatroom)
                                    .ThenInclude(c => c.ChatroomMessage)
                .Include(u => u.Collection)
                    .ThenInclude(c => c.Item_Collection)
                        .ThenInclude(ic => ic.Item)
                            .ThenInclude(i => i.MarketplaceListing)
                                .ThenInclude(ml => ml.Chatroom)
                                    .ThenInclude(c => c.Chatroom_User)
                .Include(u => u.CollectionFolder)
                .Include(u => u.Wishlist)
                    .ThenInclude(w => w.Wishlist_Item)
                .Include(u => u.MarketplaceListing)
                    .ThenInclude(ml => ml.Chatroom)
                        .ThenInclude(c => c.ChatroomMessage)
                .Include(u => u.MarketplaceListing)
                    .ThenInclude(ml => ml.Chatroom)
                        .ThenInclude(c => c.Chatroom_User)
                .Include(u => u.ShoppingLink)
                .Include(u => u.ChatroomMessage)
                .Include(u => u.Chatroom_User)
                .FirstOrDefaultAsync(u => u.UserID == id);

            if (user == null)
                return NotFound("User not found.");

            _context.Junction_Chatroom_User.RemoveRange(user.Chatroom_User);
            _context.ChatroomMessage.RemoveRange(user.ChatroomMessage);
            _context.ShoppingLink.RemoveRange(user.ShoppingLink);

            foreach (var wishlist in user.Wishlist)
                _context.Junction_Wishlist_Item.RemoveRange(wishlist.Wishlist_Item);
            _context.Wishlist.RemoveRange(user.Wishlist);

            foreach (var listing in user.MarketplaceListing)
            {
                foreach (var chatroom in listing.Chatroom)
                {
                    _context.ChatroomMessage.RemoveRange(chatroom.ChatroomMessage);
                    _context.Junction_Chatroom_User.RemoveRange(chatroom.Chatroom_User);
                }
                _context.Chatroom.RemoveRange(listing.Chatroom);
            }
            _context.Marketplace.RemoveRange(user.MarketplaceListing);

            foreach (var collection in user.Collection)
            {
                _context.Junction_Folder_Collection.RemoveRange(collection.CollectionFolder_Collection);
                foreach (var ic in collection.Item_Collection)
                {
                    var item = ic.Item;
                    if (item != null)
                    {
                        _context.Junction_Wishlist_Item.RemoveRange(item.Wishlist_Item);
                        foreach (var listing in item.MarketplaceListing)
                        {
                            foreach (var chatroom in listing.Chatroom)
                            {
                                _context.ChatroomMessage.RemoveRange(chatroom.ChatroomMessage);
                                _context.Junction_Chatroom_User.RemoveRange(chatroom.Chatroom_User);
                            }
                            _context.Chatroom.RemoveRange(listing.Chatroom);
                        }
                        _context.Marketplace.RemoveRange(item.MarketplaceListing);
                        _context.Item.Remove(item);
                    }
                }
                _context.Junction_Item_Collection.RemoveRange(collection.Item_Collection);
            }
            _context.Collection.RemoveRange(user.Collection);
            _context.CollectionFolder.RemoveRange(user.CollectionFolder);

            if (user.UserProfile != null) _context.UserProfile.Remove(user.UserProfile);
            if (user.UserLogin != null) _context.UserLogin.Remove(user.UserLogin);
            _context.User.Remove(user);

            await _context.SaveChangesAsync();

            return Ok("User and all related data deleted successfully.");
        }
    }
}