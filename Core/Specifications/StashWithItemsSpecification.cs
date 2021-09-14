using Core.Entities;

namespace Core.Specifications
{
    public class StashWithItemsSpecification : BaseSpecification<Stash>
    {
        public StashWithItemsSpecification(string sort)
        {
            AddInclude(x => x.Items);
            AddOrderBy(x => x.Name);
        }

        public StashWithItemsSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.Items);
        }
    }
}