using CollectionManagerApi.Data;
using CollectionManagerApi.DTOs;
using CollectionManagerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CollectionManagerApi.Services
{
    public class ItemService
    {
        private readonly MyDbContext _context;

        public ItemService(MyDbContext context)
        {
            _context = context;
        }

        public async Task<Item> CreateItem(CreateItemDTO dto)
        {
            if (dto.CollectionID == null && dto.WishlistID == null)
                throw new Exception("An item must be placed in either a collection or a wishlist.");

            if (dto.CollectionID != null && dto.WishlistID != null)
                throw new Exception("An item cannot be placed in both a collection and a wishlist at the same time.");

            var item = new Item
            {
                ItemName = dto.ItemName,
                ItemCount = dto.ItemCount,
                ItemValue = dto.ItemValue,
                ItemType = dto.ItemType,
                ItemDescription = dto.ItemDescription,
                PictureID = dto.PictureID,
                ItemPurchaseDate = dto.ItemPurchaseDate
            };

            _context.Item.Add(item);
            await _context.SaveChangesAsync();

            if (dto.CollectionID != null)
            {
                var collection = await _context.Collection.FindAsync(dto.CollectionID);
                if (collection == null)
                    throw new Exception("Collection ikke fundet.");

                _context.Junction_Item_Collection.Add(new Item_Collection
                {
                    ItemID = item.ItemID,
                    CollectionID = dto.CollectionID.Value
                });
            }
            else
            {
                var wishlist = await _context.Wishlist.FindAsync(dto.WishlistID);
                if (wishlist == null)
                    throw new Exception("Wishlist ikke fundet.");

                _context.Junction_Wishlist_Item.Add(new Wishlist_Item
                {
                    ItemID = item.ItemID,
                    WishlistID = dto.WishlistID.Value
                });
            }

            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<List<Item>> GetAllItems()
        {
            return await _context.Item.ToListAsync();
        }

        public async Task<object?> GetOneItem(int id)
        {
            var item = await _context.Item
                .Include(i => i.Item_Collection)
                .Include(i => i.Wishlist_Item)
                .FirstOrDefaultAsync(i => i.ItemID == id);

            if (item == null) return null;

            var collectionId = item.Item_Collection.FirstOrDefault()?.CollectionID;
            var wishlistId = item.Wishlist_Item.FirstOrDefault()?.WishlistID;

            return new
            {
                item.ItemID,
                item.ItemName,
                item.ItemDescription,
                item.ItemType,
                item.ItemValue,
                item.ItemCount,
                item.PictureID,
                item.ItemPurchaseDate,
                collectionId,
                wishlistId
            };
        }

        public async Task<List<Item>> GetItemsInCollection(int collectionId)
        {
            return await _context.Item
                .Where(i =>
                    i.Item_Collection.Any(ic =>
                        ic.CollectionID == collectionId))
                .ToListAsync();
        }

        public async Task<bool> UpdateItem(int id, UpdateItemDTO dto)
        {
            var item = await _context.Item.FindAsync(id);

            if (item == null)
            {
                return false;
            }

            item.ItemName = dto.ItemName;
            item.ItemCount = dto.ItemCount;
            item.ItemValue = dto.ItemValue;
            item.ItemType = dto.ItemType;
            item.ItemDescription = dto.ItemDescription;
            item.PictureID = dto.PictureID;
            item.ItemPurchaseDate = dto.ItemPurchaseDate;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteItem(int id)
        {
            var item = await _context.Item.FindAsync(id);

            if (item == null)
            {
                return false;
            }

            _context.Item.Remove(item);

            await _context.SaveChangesAsync();

            return true;
        }

        /*
        Mangler at implementere GetStatisticValues
        */

    }
}