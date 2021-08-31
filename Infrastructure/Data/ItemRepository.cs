using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ItemRepository : IItemRepository
    {
        private readonly StashContext _context;
        public ItemRepository(StashContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Item>> GetItemAsync()
        {
            return await _context.Items.ToListAsync();
        }

        public async Task<Item> GetItemByIdAsync(int id)
        {
            return await _context.Items.FindAsync(id);
        }
    }
}