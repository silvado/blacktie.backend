using Application.Abstractions.Messaging;
using Application.Contracts.PaymentType;

namespace Application.Commands.CreatePaymentType
{
    public sealed record CreatePaymentTypeCommand(PaymentTypeDto item) : ICommand<PaymentTypeDto>;
}
