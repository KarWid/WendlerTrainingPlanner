namespace WendlerTrainingPlanner.Application.CQRS.Mapper.Dtos.AccessoryExercise
{
    public record SuperseriesAccessoryExerciseDto(int OrderNumber, int Sets, AccessoryExercisesDto AccessoryExercises)
        : BaseAccessoryExerciseDto(OrderNumber, Sets);
}
