namespace WendlerTrainingPlanner.Application.CQRS.TrainingPlanTemplates.Commands.CreateTrainingPlanTemplate
{
    using FluentValidation;
    using WendlerTrainingPlanner.Application.CQRS.Extensions;
    using WendlerTrainingPlanner.Application.CQRS.Resources;

    internal class CreateTrainingPlanTemplateCommandValidator : AbstractValidator<CreateTrainingPlanTemplateCommand>
    {
        internal CreateTrainingPlanTemplateCommandValidator()
        {
            RuleFor(_ => _.Name).NotEmptyMaximumLength(50);
            RuleFor(_ => _.From).LaterThanTodayWithErrorMessage();

            RuleFor(_ => _.Cycles).GreaterThanWithErrorMessage(0);
            RuleFor(_ => _.TrainingMaxPercentage)
                .GreaterThanWithErrorMessage(0)
                .LessThanOrEqualToWithErrorMessage(1);

            RuleFor(_ => _.Days).NotNullWithErrorMessage();
            RuleFor(_ => _.Days.Count()).LessThanOrEqualToWithErrorMessage(7);
            RuleFor(_ => _.Days.Select(x => x.DayOfWeek))
                .HasUniqueValues().WithMessage(GeneralCqrsResource.ErrorMessage_TrainingDays_UniqueValues);

            RuleFor(_ => _.TrainingPlanTemplateTypeId).GreaterThanWithErrorMessage(0);
        }
    }
}
