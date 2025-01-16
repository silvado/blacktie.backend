using System.Diagnostics.CodeAnalysis;

namespace Domain.Entities.Abstracts
{
    [ExcludeFromCodeCoverage]
    public abstract class EntityInt : Entity
    {
        public int Id { get; set; }
    }
}
