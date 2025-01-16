using Domain.Interfaces.Common;

namespace Domain.Models
{
    public class CustomerAddress : ILinkEntity<Address>
    {
        public virtual Customer Customer { get; set; }
        public virtual Guid CustomerId { get; set; }
        public virtual Address Address { get; set; }
        public virtual int AddressId { get; set; }

        public Address GetEntity()
        {
            return Address;
        }

        public int GetEntityId()
        {
            return AddressId;
        }

        public Guid GetEntityIdGuid()
        {
            return CustomerId;
        }

        public void SetEntityId(int id)
        {
            AddressId = id;
        }
        public void SetEntityIdGuid(Guid id)
        {
            CustomerId = id;
        }
    }
}
