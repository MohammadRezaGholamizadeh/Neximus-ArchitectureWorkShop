using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neximus.WorkShop.Persistance.Infrastructure
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
