using infolimpiadas.Domain.Entity;
using infolimpiadas.Domain.Repository;
using infOlimpiadas.Infra;

namespace infolimpiadas.Repository
{
    public class AtletaRepository : BaseRepository<Atleta, int>, IAtletaRepository
    {
        public AtletaRepository() { }

        public AtletaRepository(AtletaDbContext db)
            : base(db)
        {
        }
        public async Task<Atleta> GetAtleta(int id) => await Get(id);

        public Atleta Save(Atleta atleta) => Add(atleta);

        public Task<List<Atleta>> GetAll() => base.GetAll();

        public void Update(Atleta atleta) => base.Update(atleta);
    }
}
