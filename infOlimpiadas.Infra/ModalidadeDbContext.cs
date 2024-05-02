using infolimpiadas.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace infOlimpiadas.Infra
{
    public class ModalidadeDbContext : DbContext
    {
        private IConfiguration configuration;
        public DbSet<Modalidade> Modalidades { get; set; }

        public ModalidadeDbContext(IConfiguration configuration, DbContextOptions<ModalidadeDbContext> options) : base(options)
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