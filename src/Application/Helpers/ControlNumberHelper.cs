using Domain.Interfaces.Helpers;
using Domain.Interfaces.Repository;

namespace Application.Helpers
{
    public class ControlNumberHelper: IControlNumberHelper
    {
        private readonly IControlRepository _controlRepository;

        public ControlNumberHelper(IControlRepository controlRepository) 
        { 
            _controlRepository = controlRepository; 
        }
        public int GetControlNumber()
        {
            Random rnd = new Random();

            return rnd.Next(111111, 999999);

        }

        public async Task<bool> ValidateControlNumber(Guid userId, string controlNumber)
        {
            return await _controlRepository.ValidateControl(userId, controlNumber);
            
        }
    }
}
