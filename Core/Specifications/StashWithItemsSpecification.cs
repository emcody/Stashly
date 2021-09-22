using Core.Entities;

namespace Core.Specifications
{
    public class StashWithItemsSpecification : BaseSpecification<Stash>
    {
        public StashWithItemsSpecification(StashSpecParams stashParams)
            : base(x =>
                (string.IsNullOrEmpty(stashParams.Search) || x.Name.ToLower().Contains(stashParams.Search)) &&
                 (string.IsNullOrEmpty(stashParams.Location) || x.Location == stashParams.Location)
            )
        {
            AddInclude(x => x.Items);
            AddOrderBy(x => x.Name);
            ApplyPaging(stashParams.PageSize * (stashParams.PageIndex - 1), stashParams.PageSize);

            if (!string.IsNullOrEmpty(stashParams.Sort))
            {
                switch (stashParams.Sort)
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