using CollectionManagerApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CollectionManagerApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class WishlistController : ControllerBase
    {
        private readonly WishlistService _wishlistService;

        public WishlistController(WishlistService wishlistService)
        {
            _wishlistService = wishlistService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMyWishlist()
        {
            var userIdClaim = User.FindFirst("userId")?.Value;
            if (userIdClaim == null) return Unauthorized();
            int userId = int.Parse(userIdClaim);

            var wishlist = await _wishlistService.GetWishlistForUser(userId);
            if (wishlist == null) return NotFound("No wishlist found for this user.");

            var items = await _wishlistService.GetWishlistItems(wishlist.WishlistID);

            return Ok(new
            {
                wishlistId = wishlist.WishlistID,
                wishlistName = wishlist.WishlistName,
                items
            });
        }
    }
}