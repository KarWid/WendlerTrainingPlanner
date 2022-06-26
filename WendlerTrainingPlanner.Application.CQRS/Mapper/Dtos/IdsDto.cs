namespace WendlerTrainingPlanner.Application.CQRS.Mapper.Dtos
{
    public record IdsDto(Guid CreatedId, Guid UniqueId, string Status);
}
