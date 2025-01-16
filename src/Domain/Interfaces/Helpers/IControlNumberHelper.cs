namespace Domain.Interfaces.Helpers
{
    public interface IControlNumberHelper
    {

        int GetControlNumber();
        Task<bool> ValidateControlNumber(Guid userId, string controlNumber);


    }
}
