using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IItemRepository
    {
        Task<Item> GetItemByIdAsync(int id);
        Task<IReadOnlyList<Item>> GetItemAsync();
    }
}