namespace WendlerTrainingPlanner.Api.Contracts.Dtos.AccessoryExercise
{
    public record SuperseriesAccessoryExerciseDto(int OrderNumber, int Sets, AccessoryExercisesDto AccessoryExercises)
        : BaseAccessoryExerciseDto(OrderNumber, Sets);
}
