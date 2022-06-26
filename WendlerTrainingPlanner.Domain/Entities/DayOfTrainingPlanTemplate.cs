namespace WendlerTrainingPlanner.Domain.Entities
{
    using WendlerTrainingPlanner.Domain.Ddd;
    using WendlerTrainingPlanner.Domain.Exceptions;
    using WendlerTrainingPlanner.Domain.ValueObjects;
    using WendlerTrainingPlanner.Domain.ValueObjects.AccessoryExercise;
    using WendlerTrainingPlanner.Domain.ValueObjects.Ids;

    public class DayOfTrainingPlanTemplate : Entity<DayOfTrainingPlanTemplateId, DayOfTrainingPlanTemplateUniqueId>
    {
        private DayOfWeek _dayOfWeek;
        private MainExercise _mainExercise;
        private Weight _mainExerciseWeight;
        private AccessoryExercises _accessoryExercises;

        public DayOfTrainingPlanTemplate(
            DayOfWeek dayOfWeek, 
            Weight mainExerciseWeight,
            MainExercise mainExercise,
            AccessoryExercises accessoryExercises)
        {
            if (accessoryExercises is null) throw new DomainArgumentException(DomainResource.ArgumentCannotBeNull, "AccessoryExercises");
            if (mainExercise is null) throw new DomainArgumentException(DomainResource.ArgumentCannotBeNull, "Main exercise");
            if (mainExerciseWeight is null) throw new DomainArgumentException(DomainResource.ArgumentCannotBeNull, "Main exercise weight");

            _dayOfWeek = dayOfWeek;
            _mainExercise = mainExercise;
            _mainExerciseWeight = mainExerciseWeight;
            _accessoryExercises = accessoryExercises;
        }
    }
}
