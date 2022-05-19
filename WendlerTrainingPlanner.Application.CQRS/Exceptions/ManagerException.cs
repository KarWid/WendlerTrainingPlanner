namespace WendlerTrainingPlanner.Application.CQRS.Exceptions
{
    using FluentValidation.Results;

    public class ManagerException : Exception
    {
        public ManagerException(string message) : base(message)
        {

        }

        public ManagerException(ValidationResult validationResult) : base(GetErrorMessageFromValidationResult(validationResult))
        {

        }

        // TODO: TO modify this to display list of errors as a list not as a single string value. Also, assign the errors to an objectId or something.
        private static string GetErrorMessageFromValidationResult(ValidationResult validationResult)
        {
            return string.Join(" ", validationResult.Errors.Select(_ => _.ErrorMessage));
        }
    }
}
