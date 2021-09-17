using Core.Entities;

namespace Core.Specifications
{
    public class StashesWithFiltersForCountSpecification : BaseSpecification<Stash>
    {
        public StashesWithFiltersForCountSpecification(StashSpecParams stashParams)
              : base(x =>
                 (string.IsNullOrEmpty(stashParams.Location) || x.Location == stashParams.Location)
            )
        {

        }
    }
}