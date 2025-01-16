using MediatR;
using System.Diagnostics.CodeAnalysis;
using System.Transactions;

namespace Application.Behaviors
{
    [ExcludeFromCodeCoverage]
    public sealed class TransactionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : notnull
    {

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {

            var transactionOptions = new TransactionOptions
            {
                IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted,
                Timeout = TransactionManager.MaximumTimeout
            };

            using (var transaction = new TransactionScope(TransactionScopeOption.Required, transactionOptions,
                        TransactionScopeAsyncFlowOption.Enabled))
            {
                // handle request handler
                var response = await next();

                // complete database transaction
                transaction.Complete();

                return response;
            }
        }
    }
}
