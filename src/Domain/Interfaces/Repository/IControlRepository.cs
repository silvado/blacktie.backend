using Domain.Interfaces.Common;
using Domain.Models;

namespace Domain.Interfaces.Repository
{
    public interface IControlRepository : IGenericAsyncRepository<Control>
    {
        Task<bool> ValidateControl(Guid userId, string control);
    }
}
