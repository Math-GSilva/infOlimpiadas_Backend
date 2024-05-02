using infolimpiadas.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace infOlimpiadas.Infra
{
    public class PaisDbContext : DbContext
    {
        private IConfiguration configuration;
        public DbSet<Pais> Paises { get; set; }

        public PaisDbContext(IConfiguration configuration, DbContextOptions<PaisDbContext> options) : base(options)
        {
            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var conn = configuration.GetConnectionString("SqlServer");
            optionsBuilder.UseSqlServer(conn);
        }
    }
}