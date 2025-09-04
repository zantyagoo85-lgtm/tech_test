using Microsoft.EntityFrameworkCore;
using prueba_tecnica.Domain.Entities;
using prueba_tecnica.Domain.Interfaces;
using prueba_tecnica.Infrastructure.Data;
using System.Data;

namespace prueba_tecnica.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        private readonly AppDbContext _context;

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void saveChanges()
        {
            _context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            DateTime dateShort = DateTime.SpecifyKind(Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm")), DateTimeKind.Utc);

            //Verificar si hay datos nuevos
            IEnumerable<object> insertedEntries = _context.ChangeTracker.Entries().Where(x => x.State == EntityState.Added).Select(x => x.Entity);
            foreach (object? insertedEntry in insertedEntries) { insertedEntry.GetType().GetProperty("CreatedAt")?.SetValue(insertedEntry, dateShort); }
            //Verificar si se han actualizado datos
            IEnumerable<object> modifiedEntries = _context.ChangeTracker.Entries().Where(x => x.State == EntityState.Modified).Select(x => x.Entity);
            foreach (object? modifiedEntry in modifiedEntries) { modifiedEntry.GetType().GetProperty("UpdatedAt")?.SetValue(modifiedEntry, dateShort); }
            int count = await _context.SaveChangesAsync();
            return count;
        }

        private readonly IBaseRepository<Product>? _Product = null;


        public IBaseRepository<Product> Product => _Product ?? new BaseRepository<Product>(_context);

    }
}
