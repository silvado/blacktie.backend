using Domain.Entities.Abstracts;

namespace Domain.Models
{
    public class Coupon: EntityGuid
    {
        public float Percent { get; set; }
        public int NumberOfUses { get; set; }
        public DateTime ExpireAt { get; set; }
    }
}
