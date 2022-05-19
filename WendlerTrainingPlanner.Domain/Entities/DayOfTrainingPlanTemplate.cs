namespace WendlerTrainingPlanner.Domain.Entities
{
    using WendlerTrainingPlanner.Domain.Ddd;
    using WendlerTrainingPlanner.Domain.Exceptions;
    using WendlerTrainingPlanner.Domain.ValueObjects;
    using WendlerTrainingPlanner.Domain.ValueObjects.AccessoryExercise;
    using WendlerTrainingPlanner.Domain.ValueObjects.Ids;

    public class DayOfTrainingPlanTemplate : Entity<DayOfTrainingPlanTemplateId, DayOfTrainingPlanTemplateUniqueId>
    {
        public DayOfWeek DayOfWeek { get; }
        public MainExercise MainExercise { get; }
        public Weight MainExerciseWeight { get; }

        public AccessoryExercises AccessoryExercises {get;}

        public DayOfTrainingPlanTemplate(
            DayOfWeek dayOfWeek, 
            Weight mainExerciseWeight,
            MainExercise mainExercise,
            AccessoryExercises accessoryExercises)
        {
            if (accessoryExercises is null) throw new DomainArgumentException(DomainResource.ArgumentCannotBeNull, "AccessoryExercises");
            if (mainExercise is null) throw new DomainArgumentException(DomainResource.ArgumentCannotBeNull, "Main exercise");
            if (mainExerciseWeight is null) throw new DomainArgumentException(DomainResource.ArgumentCannotBeNull, "Main exercise weight");

            DayOfWeek = dayOfWeek;
            MainExercise = mainExercise;
            MainExerciseWeight = mainExerciseWeight;
            AccessoryExercises = accessoryExercises;
        }
    }
}
