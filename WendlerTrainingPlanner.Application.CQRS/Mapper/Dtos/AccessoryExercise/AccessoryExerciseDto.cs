namespace WendlerTrainingPlanner.Application.CQRS.Mapper.Dtos.AccessoryExercise
{
    public record AccessoryExerciseDto(int OrderNumber, int Sets, string Name, int Repetitions, float Weight) 
        : BaseAccessoryExerciseDto(OrderNumber, Sets);
}
