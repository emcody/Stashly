using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StashesController : ControllerBase
    {
        private readonly IStashRepository _stashRepository;

        public StashesController(IStashRepository stashRepository)
        {
            this._stashRepository = stashRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Stash>>> GetStashes()
        {
            var stashes = await _stashRepository.GetStashesAsync();
            return Ok(stashes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Stash>> GetStashById(int id)
        {
            var stashes = await _stashRepository.GetStashByIdAsync(id);
            return Ok(stashes);
        }

        [HttpGet("{id}/items")]
        public async Task<ActionResult<Stash>> GetItemsOfStash(int id)
        {
            var items = await _stashRepository.GetItemsByStashAsync(id);
            return Ok(items);
        }
    }
}