using prueba_tecnica.Domain.Entities;

namespace prueba_tecnica.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void saveChanges();

        Task<int> SaveChangesAsync();

        IBaseRepository<Product> Product { get; }
        
    }
}
