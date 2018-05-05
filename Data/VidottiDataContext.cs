using Microsoft.EntityFrameworkCore;
using webapiefcore.Data.Maps;
using webapiefcore.Models;

namespace webapiefcore.Data
{
    public class VidottiDataContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost,11433;Database=vidottiwebapiefcore;User ID=sa;Password=DockerSql2017!;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProductMap());
            builder.ApplyConfiguration(new CategoryMap());
        }
    }
}