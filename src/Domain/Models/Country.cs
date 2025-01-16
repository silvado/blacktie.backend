using Domain.Entities.Abstracts;

namespace Domain.Models
{
    public class Country : EntityInt
    {
        public string Name { get; set; }
        public string? CallingCode { get; set; }
    }
}
