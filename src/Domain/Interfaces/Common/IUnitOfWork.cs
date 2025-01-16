using Domain.Interfaces.Repository;

namespace Domain.Interfaces.Common
{
    public interface IUnitOfWork
    {
        void Commit();
        Task CommitAsync();

        ISistemaRepository SistemaRepository { get; }
        ISistemaCredencialRepository SistemaCredencialRepository { get; }
        ISistemaPublicacaoRepository SistemaPublicacaoRepository { get; }
    }
}
