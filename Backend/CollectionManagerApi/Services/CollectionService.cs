using CollectionManagerApi.Data;
using CollectionManagerApi.DTOs;
using CollectionManagerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CollectionManagerApi.Services
{
    public class CollectionService
    {
        private readonly MyDbContext _context;

        public CollectionService(MyDbContext context)
        {
            _context = context;
        }

        public async Task<Collection> CreateCollection(CreateCollectionDTO dto, int userId)
        {
            var collection = new Collection
            {
                CollectionName = dto.CollectionName,
                CollectionDescription = dto.CollectionDescription,
                UserID = userId
            };

            _context.Collection.Add(collection);
            await _context.SaveChangesAsync();
            return collection;
        }

        public async Task<List<Collection>> GetAllCollections(int userId)
        {
            return await _context.Collection
                    .Where(c => c.UserID == userId)
                    .ToListAsync();
        }

        public async Task<Collection?> GetOneCollection(int id)
        {
            return await _context.Collection.FindAsync(id);
        }

        public async Task<bool> UpdateCollection(int id, UpdateCollectionDTO dto)
        {
            var existingCollection = await _context.Collection.FindAsync(id);

            if (existingCollection == null)
            {
                return false;
            }

            existingCollection.CollectionName = dto.CollectionName;
            existingCollection.CollectionDescription = dto.CollectionDescription;

            await _context.SaveChangesAsync();
            
            return true;
        }

        public async Task<bool> DeleteCollection(int id)
        {
            var collection = await _context.Collection.FindAsync(id);

            if (collection == null)
            {
                return false;
            }

            _context.Collection.Remove(collection);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
