using DemoWebApi.Model;
using Microsoft.EntityFrameworkCore;

namespace DemoWebApi.Context
{
    public class DemoWebApiDbContext: DbContext
    {
        public DemoWebApiDbContext(DbContextOptions<DemoWebApiDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Students> Students { get; set; }
    }
}
