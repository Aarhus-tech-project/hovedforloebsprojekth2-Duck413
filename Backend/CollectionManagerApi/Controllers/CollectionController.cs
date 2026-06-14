using CollectionManagerApi.DTOs;
using CollectionManagerApi.Models;
using CollectionManagerApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CollectionManagerApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CollectionController : ControllerBase
    {
        private readonly CollectionService _collectionService;

        public CollectionController(CollectionService collectionService)
        {
            _collectionService = collectionService;
        }

        [HttpPost]
        public async Task<ActionResult<Collection>> CreateCollection(CreateCollectionDTO dto)
        {
            var createdCollection = await _collectionService.CreateCollection(dto);
            
            return CreatedAtAction(
                nameof(GetOneCollection),
                new {id = createdCollection.CollectionId},
                createdCollection);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Collection>>> GetAllCollections()
        {
            var collections = await _collectionService.GetAllCollections();

            return Ok(collections);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Collection>> GetOneCollection(int id)
        {
            var collection = await _collectionService.GetOneCollection(id);

            if (collection == null)
            {
                return NotFound();
            }

            return Ok(collection);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCollection(int id, UpdateCollectionDTO dto)
        {
            var success = await _collectionService.UpdateCollection(id, dto);

            if(!success)
            {
                return NotFound();
            }
                
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCollection(int id)
        {
            var success =
                await _collectionService.DeleteCollection(id);

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}