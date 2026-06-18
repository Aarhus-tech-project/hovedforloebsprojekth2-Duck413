using CollectionManagerApi.DTOs;
using CollectionManagerApi.Models;
using CollectionManagerApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CollectionManagerApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly ItemService _itemService;

        public ItemController(ItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpPost]
        public async Task<ActionResult<Item>> CreateItem(CreateItemDTO dto)
        {
            try
            {
                var item = await _itemService.CreateItem(dto);
                return CreatedAtAction(nameof(GetOneItem), new { id = item.ItemID }, item);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetAllItems()
        {
            var items =
                await _itemService.GetAllItems();

            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<object>> GetOneItem(int id)
        {
            var item = await _itemService.GetOneItem(id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpGet("collection/{collectionId}")]
        public async Task<ActionResult<IEnumerable<Item>>> GetItemsInCollection(
            int collectionId)
        {
            var items =
                await _itemService.GetItemsInCollection(collectionId);

            return Ok(items);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItem(
            int id,
            UpdateItemDTO dto)
        {
            var success =
                await _itemService.UpdateItem(id, dto);

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var success =
                await _itemService.DeleteItem(id);

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}