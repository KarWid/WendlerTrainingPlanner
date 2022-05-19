namespace WendlerTrainingPlanner.Domain.ValueObjects.Ids
{
    using WendlerTrainingPlanner.Domain.Ddd;
    using WendlerTrainingPlanner.Domain.Enums;

    public class Ids<T1, UniqueT2> 
        where T1 : ValueObject<T1> 
        where UniqueT2 : ValueObject<UniqueT2>
    {
        public BaseId<T1> CreatedId { get; set; }
        public BaseUniqueId<UniqueT2> UniqueId { get; set; }

        public IdsStatus Status { get; set; }
    }
}
