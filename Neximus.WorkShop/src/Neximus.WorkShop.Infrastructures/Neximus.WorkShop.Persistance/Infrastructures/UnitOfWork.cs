using Neximus.WorkShop.Services.Infrastructures.Contracts;

namespace Neximus.WorkShop.Persistance.Infrastructures
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EFDataContext _context;

        public UnitOfWork(EFDataContext context)
        {
            _context = context;
        }
        public async Task BeginTransaction()
        {
            await _context.Database.BeginTransactionAsync();
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
            await _context.Database.CommitTransactionAsync();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
