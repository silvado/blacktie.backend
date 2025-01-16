using Domain.Entities.Abstracts;

namespace Domain.Models
{
    public class PaymentType : EntityInt
    {
        public string Name { get; set; }
        public string CodeName { get; set; }
    }
}
