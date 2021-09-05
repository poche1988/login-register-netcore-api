using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>().ToTable("AspNetUsers");

            base.OnModelCreating(modelBuilder);
        }
    }
}
