using FluentValidation.Results;
using MediatR;
using System.Text.Json.Serialization;

namespace Domain.Command.Base
{
    public abstract class BaseCommand<T> : IRequest<T>
    {
        [JsonIgnore]
        public DateTime Timestamp { get; private set; } = DateTime.Now;

        public ValidationResult? ValidationResult { get; protected set; }

        public virtual bool IsValid()
        {
            throw new NotImplementedException();
        }
    }

    public abstract class Command : BaseCommand<ValidationResult> { }
}
