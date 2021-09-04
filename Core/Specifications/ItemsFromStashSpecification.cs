using Core.Entities;

namespace Core.Specifications
{
    public class ItemsFromStashSpecification : BaseSpecification<Item>
    {
        public ItemsFromStashSpecification(int stashId) : base(x => x.StashId == stashId)
        {
        }
    }
}