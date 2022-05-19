namespace WendlerTrainingPlanner.Application.CQRS.Mapper.Validators.AccessoryExercise
{
    using FluentValidation;
    using WendlerTrainingPlanner.Application.CQRS.Extensions;
    using WendlerTrainingPlanner.Application.CQRS.Mapper.Dtos.AccessoryExercise;

    internal class BaseAccessoryExerciseValidator<T> : AbstractValidator<T> where T : BaseAccessoryExerciseDto
    {
        internal BaseAccessoryExerciseValidator()
        {
            RuleFor(_ => _.Sets).GreaterThanWithErrorMessage(0);
            RuleFor(_ => _.OrderNumber).GreaterThanWithErrorMessage(0);
        }
    }
}
