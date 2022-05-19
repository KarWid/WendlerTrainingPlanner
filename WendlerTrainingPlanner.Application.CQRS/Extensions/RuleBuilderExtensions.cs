namespace WendlerTrainingPlanner.Application.CQRS.Extensions
{
    using FluentValidation;
    using WendlerTrainingPlanner.Application.CQRS.Resources;
    using WendlerTrainingPlanner.Domain;
    using WendlerTrainingPlanner.Domain.Constants;

    public static class RuleBuilderExtensions
    {
        public static IRuleBuilderOptions<T, string> MatchesLettersOnlyWithMaximumLength<T>(
            this IRuleBuilderInitial<T, string> rule,
            int maximumLength)
        {
            return rule
                .NotNull().WithMessage(GeneralCqrsResource.ErrorMessage_Required)
                .Matches(Constant.Regex.LETTERS_ONLY).WithMessage(GeneralCqrsResource.ErrorMessage_InvalidFormatLettersOnly)
                .MaximumLength(maximumLength).WithMessage(GeneralCqrsResource.ErrorMessage_MaximumLength);
        }

        public static IRuleBuilderOptions<T, string> NotEmptyMaximumLength<T>(
            this IRuleBuilderInitial<T, string> rule,
            int maximumLength)
        {
            return rule
                .NotEmpty().WithMessage(GeneralCqrsResource.ErrorMessage_Required)
                .MaximumLength(maximumLength).WithMessage(GeneralCqrsResource.ErrorMessage_MaximumLength);
        }

        public static IRuleBuilderOptions<T, T2> NotNullWithErrorMessage<T, T2>(
            this IRuleBuilderInitial<T, T2> rule)
        {
            return rule.NotNull().WithMessage(GeneralCqrsResource.ErrorMessage_Required);
        }

        public static IRuleBuilderOptions<T, TProperty> GreaterThanWithErrorMessage<T, TProperty>(
            this IRuleBuilderInitial<T, TProperty> rule, TProperty value) where TProperty : IComparable<TProperty>, IComparable
        {
            return rule.GreaterThan(value).WithMessage(GeneralCqrsResource.ErrorMessage_GreaterThan);
        }

        public static IRuleBuilderOptions<T, TProperty> LessThanOrEqualToWithErrorMessage<T, TProperty>(
            this IRuleBuilder<T, TProperty> rule, TProperty value) where TProperty : IComparable<TProperty>, IComparable
        {
            return rule.LessThanOrEqualTo(value).WithMessage(GeneralCqrsResource.ErrorMessage_LessThanOrEqualTo);
        }

        public static IRuleBuilderOptions<T, IEnumerable<TModel>> HasUniqueValues<T, TModel>(
            this IRuleBuilderInitial<T, IEnumerable<TModel>> rule)
        {
            return rule.Must((rootObject, list, context) =>
            {
                var uniqueOrderNumbers = new HashSet<TModel>(list);
                return uniqueOrderNumbers.Count == list.Count();
            });
        }

        // TODO: To test
        public static IRuleBuilderOptions<T, DateTime> EarlierThanTodayWithErrorMessage<T>(this IRuleBuilderInitial<T, DateTime> rule)
        {
            return rule.LessThan(AppTime.Now()).WithMessage(GeneralCqrsResource.ErrorMessage_EarlierThan);
        }

        public static IRuleBuilderOptions<T, DateTime> LaterThanTodayWithErrorMessage<T>(this IRuleBuilderInitial<T, DateTime> rule)
        {
            return rule.GreaterThan(AppTime.Now()).WithMessage(GeneralCqrsResource.ErrorMessage_LaterThan);
        }
    }
}
