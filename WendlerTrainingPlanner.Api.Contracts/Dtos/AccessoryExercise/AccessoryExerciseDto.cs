namespace WendlerTrainingPlanner.Api.Contracts.Dtos.AccessoryExercise
{
    public record AccessoryExerciseDto(int OrderNumber, string Name, int Sets, int Repetitions, float Weight)
        : BaseAccessoryExerciseDto(OrderNumber, Sets);
}
