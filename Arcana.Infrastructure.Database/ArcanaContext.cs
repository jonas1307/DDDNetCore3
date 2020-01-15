using Microsoft.EntityFrameworkCore;

namespace Arcana.Infrastructure.Database
{
    public class ArcanaContext : DbContext
    {
        public ArcanaContext()
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
