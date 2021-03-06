using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StashesController : ControllerBase
    {
        private readonly IGenericRepository<Stash> _stashRepository;
        private readonly IGenericRepository<Item> _itemsRepository;
        private readonly IMapper _mapper;

        public StashesController(IGenericRepository<Stash> stashRepository, IGenericRepository<Item> itemsRepository, IMapper mapper)
        {
            _mapper = mapper;
            _stashRepository = stashRepository;
            _itemsRepository = itemsRepository;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<StashToReturnDto>>> GetStashes(
            [FromQuery] StashSpecParams stashParams)
        {
            var spec = new StashWithItemsSpecification(stashParams);
            var countSpec = new StashesWithFiltersForCountSpecification(stashParams);

            var totalStashes = await _stashRepository.CountAsync(countSpec);
            var stashes = await _stashRepository.ListAsync(spec);

 
            var data = _mapper.Map<IReadOnlyList<Stash>,IReadOnlyList<StashToReturnDto>>(stashes);

            return Ok(new Pagination<StashToReturnDto>(stashParams.PageIndex,stashParams.PageSize,totalStashes,data));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StashToReturnDto>> GetStashById(int id)
        {
            var spec = new StashWithItemsSpecification(id);
            var stash = await _stashRepository.GetEntityWithSpec(spec);

            var stashToReturn = _mapper.Map<Stash,StashToReturnDto>(stash);
            return Ok(stashToReturn);
        }

        [HttpGet("{id}/items")]
        public async Task<ActionResult<IReadOnlyList<ItemToReturnDto>>> GetItemsOfStash(int id)
        {
            var spec = new ItemsFromStashSpecification(id);
            var items = await _itemsRepository.ListAsync(spec);
            var itemsToReturn = _mapper.Map<IReadOnlyList<Item>,IReadOnlyList<ItemToReturnDto>>(items);
            return Ok(itemsToReturn);
        }
    }
}