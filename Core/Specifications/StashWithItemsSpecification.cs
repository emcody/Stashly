using Core.Entities;

namespace Core.Specifications
{
    public class StashWithItemsSpecification : BaseSpecification<Stash>
    {
        public StashWithItemsSpecification()
        {
            AddInclude(x => x.Items);
        }

        public StashWithItemsSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.Items);
        }
    }
}