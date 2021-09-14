using Core.Entities;

namespace Core.Specifications
{
    public class StashWithItemsSpecification : BaseSpecification<Stash>
    {
        public StashWithItemsSpecification(string sort)
        {
            AddInclude(x => x.Items);
            AddOrderBy(x => x.Name);

            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
                {
                    case "ownerIdAsc":
                        AddOrderBy(s => s.OwnerId);
                        break;
                    case "ownerIdDesc":
                        AddOrderByDescending(s => s.OwnerId);
                        break;
                    case "locationAsc":
                        AddOrderBy(s => s.Location);
                        break;
                    case "locationDesc":
                        AddOrderByDescending(s => s.Location);
                        break;
                    default:
                        AddOrderBy(x => x.Name);
                        break;
                }
            }
        }

        public StashWithItemsSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.Items);
        }
    }
}