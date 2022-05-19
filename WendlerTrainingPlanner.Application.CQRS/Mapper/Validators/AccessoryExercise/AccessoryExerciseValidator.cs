namespace WendlerTrainingPlanner.Application.CQRS.Mapper.Validators.AccessoryExercise
{
    using WendlerTrainingPlanner.Application.CQRS.Extensions;
    using WendlerTrainingPlanner.Application.CQRS.Mapper.Dtos.AccessoryExercise;

    internal class AccessoryExerciseValidator : BaseAccessoryExerciseValidator<AccessoryExerciseDto>
    {
        internal AccessoryExerciseValidator()
        {
            RuleFor(_ => _.Name).NotEmptyMaximumLength(50);
            RuleFor(_ => _.Weight).GreaterThanWithErrorMessage(0);
            RuleFor(_ => _.Repetitions).GreaterThanWithErrorMessage(0);
        }
    }
}
