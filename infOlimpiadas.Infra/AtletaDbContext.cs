using infolimpiadas.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace infOlimpiadas.Infra
{
    public class AtletaDbContext : DbContext
    {
        private IConfiguration configuration;
        public DbSet<Atleta> Atletas { get; set; }  

        public AtletaDbContext(IConfiguration configuration, DbContextOptions<AtletaDbContext> options) : base(options)
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