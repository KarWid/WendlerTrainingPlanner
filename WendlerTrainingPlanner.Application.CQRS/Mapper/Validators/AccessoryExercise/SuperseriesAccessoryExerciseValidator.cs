namespace WendlerTrainingPlanner.Application.CQRS.Mapper.Validators.AccessoryExercise
{
    using WendlerTrainingPlanner.Application.CQRS.Extensions;
    using WendlerTrainingPlanner.Application.CQRS.Mapper.Dtos.AccessoryExercise;

    internal class SuperseriesAccessoryExerciseValidator : BaseAccessoryExerciseValidator<SuperseriesAccessoryExerciseDto>
    {
        internal SuperseriesAccessoryExerciseValidator()
        {
            RuleFor(_ => _.AccessoryExercises).SetValidator(new AccessoryExercisesValidator());
        }
    }
}
