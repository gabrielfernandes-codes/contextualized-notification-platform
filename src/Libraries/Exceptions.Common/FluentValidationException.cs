using FluentValidation.Results;


namespace Exceptions.Common;

public class FluentValidationException : Exception
{
    public IList<ValidationFailure> Errors { get; }

    public FluentValidationException(ValidationResult validationResult)
        : base(BuildErrorMessage(validationResult.Errors))
    {
        Errors = validationResult.Errors;
    }

    public FluentValidationException(IEnumerable<ValidationFailure> failures)
        : base(BuildErrorMessage(failures))
    {
        Errors = failures.ToList();
    }

    private static string BuildErrorMessage(IEnumerable<ValidationFailure> failures)
    {
        var errorMessages = failures.Select(failure => failure.ErrorMessage);

        return $"Validation failed: {string.Join(", ", errorMessages)}";
    }
}