using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StashesController : ControllerBase
    {
        private readonly IGenericRepository<Stash> _stashRepository;
        private readonly IGenericRepository<Item> _itemsRepository;

        public StashesController(IGenericRepository<Stash> stashRepository, IGenericRepository<Item> itemsRepository)
        {
            _stashRepository = stashRepository;
            _itemsRepository = itemsRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Stash>>> GetStashes()
        {
            var stashes = await _stashRepository.ListAllAsync();
            var stashesToReturn = new List<StashToReturnDto>();
            foreach (var stash in stashes)
            {
                var itemsToReturn = CreateListOfItemDto(stash.Items);
                var stashToReturn = CreateStashDto(stash, itemsToReturn);
                stashesToReturn.Add(stashToReturn);
            }
            return Ok(stashesToReturn);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StashToReturnDto>> GetStashById(int id)
        {
            var stash = await _stashRepository.GetByIdAsync(id);
            var itemsToReturn = CreateListOfItemDto(stash.Items);
            var stashToReturn = CreateStashDto(stash, itemsToReturn);
            return Ok(stashToReturn);
        }

        [HttpGet("{id}/items")]
        public async Task<ActionResult<List<Item>>> GetItemsOfStash(int id)
        {
            var items = await _stashRepository.GetItemsByStashAsync(id);
            var itemsToReturn = CreateListOfItemDto(items);
            return Ok(itemsToReturn);
        }

        private StashToReturnDto CreateStashDto(Stash stash, IEnumerable<ItemToReturnDto> items)
        {
            return new StashToReturnDto
            {
                Id = stash.Id,
                Description = stash.Description,
                Name = stash.Name,
                Location = stash.Location,
                OwnerId = stash.OwnerId,
                Items = items.ToList()
            };
        }

        private ItemToReturnDto CreateItemDto(Item item)
        {
            return new ItemToReturnDto
            {
                Id = item.Id,
                Name = item.Name,
                Quantity = item.Quantity,
                Description = item.Description,
                PictureUrl = item.PictureUrl,
                ExpirationDate = item.ExpirationDate
            };
        }
        private IEnumerable<ItemToReturnDto> CreateListOfItemDto(IEnumerable<Item> items)
        {
            var itemsToReturn = new List<ItemToReturnDto>();
            foreach (var item in items)
            {
                itemsToReturn.Add(CreateItemDto(item));
            }
            return itemsToReturn;
        }
    }
}