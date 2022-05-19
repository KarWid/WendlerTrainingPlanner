namespace WendlerTrainingPlanner.Application.CQRS.Mapper.Validators.AccessoryExercise
{
    using FluentValidation;
    using WendlerTrainingPlanner.Application.CQRS.Extensions;
    using WendlerTrainingPlanner.Application.CQRS.Mapper.Dtos.AccessoryExercise;
    using WendlerTrainingPlanner.Application.CQRS.Resources;

    internal class AccessoryExercisesValidator : AbstractValidator<AccessoryExercisesDto>
    {
        internal AccessoryExercisesValidator()
        {
            RuleForEach(_ => _.Accessories).SetValidator(new BaseAccessoryExerciseValidator<BaseAccessoryExerciseDto>());

            RuleFor(_ => _.Accessories.Select(x => x.OrderNumber))
                .HasUniqueValues().WithMessage(GeneralCqrsResource.ErrorMessage_OrderNumbersUniqueValues);
        }
    }
}
