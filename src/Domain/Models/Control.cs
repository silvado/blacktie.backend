using Domain.Entities.Abstracts;

namespace Domain.Models
{
    public class Control : EntityGuid
    {
        public Guid UserId { get; set; }
        public string? ControlNumber { get; set; }
        public DateTime ExpireAt { get; set; }
    }
}
