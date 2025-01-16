using FluentValidation.Results;
using System.Diagnostics.CodeAnalysis;

namespace Domain.Handlers.Base
{
    [ExcludeFromCodeCoverage]
    public abstract class CommandHandler
    {
        protected ValidationResult ValidationResult;

        protected CommandHandler() => ValidationResult = new ValidationResult();

        protected void AddError(string message) => ValidationResult.Errors.Add(new ValidationFailure(string.Empty, message));

    }
}
