using Domain.Interfaces.Common;
using Domain.Interfaces.Repository;
using Infrastructure.Context;
using Infrastructure.Repository;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public BlacktieDbContext Context { get; private set; }
        private IServiceProvider _services;
        private bool disposed = false;

        public UnitOfWork() { }

        public UnitOfWork(BlacktieDbContext context, IServiceProvider services)
        {
            this.Context = context;
            _services = services;
        }

        public void Commit()
        {
            Context.SaveChanges();
        }


        private ISistemaRepository _sistemaRepository = null;
        public ISistemaRepository SistemaRepository => _sistemaRepository ?? new SistemaRepository(Context);


        private ISistemaCredencialRepository _sistemaCredencialRepository = null;
        public ISistemaCredencialRepository SistemaCredencialRepository => _sistemaCredencialRepository ?? new SistemaCredencialRepository(Context);


        private ISistemaPublicacaoRepository _sistemaPublicacaoRepository = null;
        public ISistemaPublicacaoRepository SistemaPublicacaoRepository => _sistemaPublicacaoRepository ?? new SistemaPublicacaoRepository(Context);

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task CommitAsync()
        {
            try
            {
                await Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
