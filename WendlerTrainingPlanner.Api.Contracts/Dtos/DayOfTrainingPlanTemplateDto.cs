namespace WendlerTrainingPlanner.Api.Contracts.Dtos
{
    using WendlerTrainingPlanner.Api.Contracts.Dtos.AccessoryExercise;

    public record DayOfTrainingPlanTemplateDto(DayOfWeek DayOfWeek, int MainExerciseId, float MainExerciseWeight, AccessoryExercisesDto AccessoryExercises);
}
