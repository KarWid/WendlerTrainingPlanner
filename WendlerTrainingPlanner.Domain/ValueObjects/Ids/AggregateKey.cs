namespace WendlerTrainingPlanner.Domain.ValueObjects.Ids
{
    using WendlerTrainingPlanner.Domain.Ddd;

    public class AggregateKey : ValueObject<AggregateKey>
    {
        public string Type { get; set; } = string.Empty;
        public string Id { get; set; } = string.Empty;

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            yield return Type;
            yield return Id;
        }

        public static readonly AggregateKey Empty = new AggregateKey();

        public override string ToString()
        {
            return Id;
        }
    }
}
