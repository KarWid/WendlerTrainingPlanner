namespace WendlerTrainingPlanner.Domain.Ddd
{
    public abstract class BaseEntity<TId>
    {
        public TId? Id { get; protected set; }
        public string CreatedBy { get; protected set; } = string.Empty;
        public DateTimeOffset CreatedDate { get; protected set; }
        public string? LastModifiedBy { get; protected set; }
        public DateTimeOffset? LastModifiedDate { get; protected set; }
    }
    public abstract class Entity<TId, TUniqueId> : BaseEntity<TId>
    {
        public TUniqueId UniqueId { get; protected set; }
        public int Version { get; protected set; }
    }
}
