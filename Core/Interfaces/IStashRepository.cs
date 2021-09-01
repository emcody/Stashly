using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IStashRepository
    {
        Task<Item> GetItemByIdAsync(int id);
        Task<IReadOnlyList<Item>> GetItemsByStashAsync(int stashId);
        Task<IReadOnlyList<Item>> GetItemsAsync();
        Task<Stash> GetStashByIdAsync(int id);
        Task<IReadOnlyList<Stash>> GetStashesAsync();
    }
}