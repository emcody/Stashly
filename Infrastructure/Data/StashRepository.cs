using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class StashRepository : IStashRepository
    {
        private readonly StashContext _context;
        public StashRepository(StashContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Item>> GetItemsAsync()
        {
            return await _context.Items.ToListAsync();
        }

        public async Task<Item> GetItemByIdAsync(int id)
        {
            return await _context.Items.FindAsync(id);
        }

        public async Task<Stash> GetStashByIdAsync(int id)
        {
            return await _context.Stashes
            .Include(s => s.Items)
            .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IReadOnlyList<Stash>> GetStashesAsync()
        {
            return await _context.Stashes
                .Include(s => s.Items)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<Item>> GetItemsByStashAsync(int stashId)
        {
            return await _context.Items.Where(i => i.StashId == stashId).ToListAsync();
        }
    }
}