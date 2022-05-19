namespace WendlerTrainingPlanner.Application.CQRS.Mapper.Dtos
{
    using WendlerTrainingPlanner.Application.CQRS.Mapper.Dtos.AccessoryExercise;

    public record DayOfTrainingPlanTemplateDto(DayOfWeek DayOfWeek, int MainExerciseId, float MainExerciseWeight, AccessoryExercisesDto AccessoryExercises);
}
