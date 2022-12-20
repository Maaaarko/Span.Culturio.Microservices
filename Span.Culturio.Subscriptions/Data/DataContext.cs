using Microsoft.EntityFrameworkCore;

namespace Span.Culturio.Subscriptions.Data.Entities {
    public class DataContext : DbContext {
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Visits> Visits { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        }
    }
}
