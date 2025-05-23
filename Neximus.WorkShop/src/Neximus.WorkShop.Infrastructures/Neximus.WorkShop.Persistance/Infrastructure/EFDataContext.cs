using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neximus.WorkShop.Persistance.Infrastructure
{
    public class EFDataContext : DbContext
    {

        public EFDataContext(DbContextOptions<EFDataContext> options) : base(options)
        {
        }

        public EFDataContext(string connectionString)
            : this(new DbContextOptionsBuilder<EFDataContext>()
                   .UseSqlServer(connectionString)
                   .Options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

        public override ChangeTracker ChangeTracker
        {
            get
            {
                var changeTracker = base.ChangeTracker;
                changeTracker.QueryTrackingBehavior =
                    QueryTrackingBehavior.TrackAll;
                changeTracker.LazyLoadingEnabled = true;
                changeTracker.AutoDetectChangesEnabled = true;
                return changeTracker;
            }
        }

    }
}
