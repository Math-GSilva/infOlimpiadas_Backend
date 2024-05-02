using infolimpiadas.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace infOlimpiadas.Infra
{
    public class MedalhaDbContext : DbContext
    {
        private IConfiguration configuration;
        public DbSet<Medalha> Medalhas { get; set; }

        public MedalhaDbContext(IConfiguration configuration, DbContextOptions<MedalhaDbContext> options) : base(options)
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