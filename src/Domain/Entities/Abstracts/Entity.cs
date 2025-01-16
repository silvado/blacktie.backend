using System.Diagnostics.CodeAnalysis;

namespace Domain.Entities.Abstracts
{
    [ExcludeFromCodeCoverage]
    public abstract class Entity
    {
        public const bool IS_VALID = true;
        public const bool IS_NOT_VALID = false;
        public const bool ERROR_BUSINESS = false;
        public List<string> MessagesToReturn = new List<string>();

        public string? CreatedByUserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string? UpdatedByUserId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeleteAt { get; set; }
        public string? DeletedByUserId { get; set; }
        
    }
}
