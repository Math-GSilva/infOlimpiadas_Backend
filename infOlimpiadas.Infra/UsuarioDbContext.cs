using infolimpiadas.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace infOlimpiadas.Infra
{
    public class UsuarioDbContext : DbContext
    {
        private IConfiguration configuration;
        public DbSet<Usuario> Usuarios { get; set; }

        public UsuarioDbContext(IConfiguration configuration, DbContextOptions<UsuarioDbContext> options) : base(options)
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