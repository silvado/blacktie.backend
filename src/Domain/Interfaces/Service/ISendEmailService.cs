using Domain.Models;

namespace Domain.Interfaces.Service
{
    public interface ISendEmailService
    {
        Task SendEmailAsync(EmailRequest mailRequest);
        string CarregaCorpoEmail(string mensagem);
    }
}
