using CollectionManagerApi.Data;
using CollectionManagerApi.Models;
using Microsoft.EntityFrameworkCore;


namespace CollectionManagerApi.Services
{
    public class WishlistService
    {
        private readonly MyDbContext _context;

        public WishlistService(MyDbContext context)
        {
            _context = context;
        }

        public async Task<Wishlist?> GetWishlistForUser(int userId)
        {
            return await _context.Wishlist
                .FirstOrDefaultAsync(w => w.UserID == userId);
        }

        public async Task<List<Item>> GetWishlistItems(int wishlistId)
        {
            return await _context.Item
                .Where(i => i.Wishlist_Item.Any(wi => wi.WishlistID == wishlistId))
                .ToListAsync();
        }
    }

    /*
    Mangler at implementere GetOneWishlistItem(), UpdateWishlistItem(), DeleteWishlistItem(), 
    DragAndDropWishlistItem() og ShareWishlist()
    */
}