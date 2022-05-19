namespace WendlerTrainingPlanner.Application.CQRS.Mapper.Validators
{
    using FluentValidation;
    using WendlerTrainingPlanner.Application.CQRS.Extensions;
    using WendlerTrainingPlanner.Application.CQRS.Mapper.Dtos;
    using WendlerTrainingPlanner.Application.CQRS.Mapper.Validators.AccessoryExercise;

    internal class DayOfTrainingPlanTemplateValidator : AbstractValidator<DayOfTrainingPlanTemplateDto>
    {
        internal DayOfTrainingPlanTemplateValidator()
        {
            RuleFor(_ => _.AccessoryExercises)
                .NotNullWithErrorMessage()
                .SetValidator(new AccessoryExercisesValidator());

            RuleFor(_ => _.MainExerciseWeight).GreaterThanWithErrorMessage(0);
        }
    }
}
