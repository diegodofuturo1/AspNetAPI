using Domain.Entities;
using Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts
{
    public class UserContext: DbContext 
    {
        public UserContext()
        {

        }

        public UserContext(DbContextOptions<UserContext> options): base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserMap());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder) => builder.UseSqlServer("Server=localhost;Database=master;User Id=root;Password=123456;Trusted_Connection=True;");
    }
}
