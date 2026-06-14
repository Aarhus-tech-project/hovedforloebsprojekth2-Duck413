using CollectionManagerApi.Data;
using CollectionManagerApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

/*namespace CollectionManagerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReadController : ControllerBase
    {
        private readonly MyDbContext _db;

        public ReadController(MyDbContext db)
        {
            _db = db;
        }

        [HttpGet("chatrooms")]
        public async Task<ActionResult<IEnumerable<ChatroomModel>>> GetChatrooms() => Ok(await _db.Chatroom.AsNoTracking().ToListAsync());

        [HttpGet("chatroom-messages")]
        public async Task<ActionResult<IEnumerable<ChatroomMessageModel>>> GetChatroomMessages() => Ok(await _db.ChatroomMessage.AsNoTracking().ToListAsync());

        [HttpGet("chatroom-users")]
        public async Task<ActionResult<IEnumerable<Chatroom_UserModel>>> GetChatroomUsers() => Ok(await _db.Junction_Chatroom_User.AsNoTracking().ToListAsync());

        [HttpGet("collection-folders")]
        public async Task<ActionResult<IEnumerable<CollectionFolderModel>>> GetCollectionFolders() => Ok(await _db.CollectionFolder.AsNoTracking().ToListAsync());

        [HttpGet("collections")]
        public async Task<ActionResult<IEnumerable<CollectionModel>>> GetCollections() => Ok(await _db.Collection.AsNoTracking().ToListAsync());

        [HttpGet("collection-folder-collections")]
        public async Task<ActionResult<IEnumerable<CollectionFolder_CollectionModel>>> GetCollectionFolderCollections() => Ok(await _db.Junction_Folder_Collection.AsNoTracking().ToListAsync());

        [HttpGet("items")]
        public async Task<ActionResult<IEnumerable<ItemModel>>> GetItems() => Ok(await _db.Item.AsNoTracking().ToListAsync());

        [HttpGet("item-collections")]
        public async Task<ActionResult<IEnumerable<Item_CollectionModel>>> GetItemCollections() => Ok(await _db.Junction_Item_Collection.AsNoTracking().ToListAsync());

        [HttpGet("marketplace-listings")]
        public async Task<ActionResult<IEnumerable<MarketplaceListingModel>>> GetMarketplaceListings() => Ok(await _db.Marketplace.AsNoTracking().ToListAsync());

        [HttpGet("pictures")]
        public async Task<ActionResult<IEnumerable<PictureModel>>> GetPictures() => Ok(await _db.Picture.AsNoTracking().ToListAsync());

        [HttpGet("shopping-links")]
        public async Task<ActionResult<IEnumerable<ShoppingLinkModel>>> GetShoppingLinks() => Ok(await _db.ShoppingLink.AsNoTracking().ToListAsync());

        [HttpGet("user-logins")]
        public async Task<ActionResult<IEnumerable<UserLoginModel>>> GetUserLogins() => Ok(await _db.UserLogin.AsNoTracking().ToListAsync());

        [HttpGet("users")]
        public async Task<ActionResult<IEnumerable<UserModel>>> GetUsers() => Ok(await _db.User.AsNoTracking().ToListAsync());

        [HttpGet("user-profiles")]
        public async Task<ActionResult<IEnumerable<UserProfileModel>>> GetUserProfiles() => Ok(await _db.UserProfile.AsNoTracking().ToListAsync());

        [HttpGet("wishlists")]
        public async Task<ActionResult<IEnumerable<WishlistModel>>> GetWishlists() => Ok(await _db.Wishlist.AsNoTracking().ToListAsync());

        [HttpGet("wishlist-items")]
        public async Task<ActionResult<IEnumerable<Wishlist_ItemModel>>> GetWishlistItems() => Ok(await _db.Junction_Wishlist_Item.AsNoTracking().ToListAsync());
    }
}*/
