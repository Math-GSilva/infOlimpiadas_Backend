using infolimpiadas.Domain.Entity;
using infolimpiadas.Domain.Repository;
using infOlimpiadas.Infra;

namespace infolimpiadas.Repository
{
    public class AtletaRepository : BaseRepository<Atleta, string>, IAtletaRepository
    {
        public AtletaRepository() { }

        public AtletaRepository(AtletaDbContext db)
            : base(db)
        {
        }
        public async Task<Atleta> GetAtleta(string id) => await Get(id);

        public Atleta Save(Atleta atleta) => Add(atleta);

        public Task<List<Atleta>> GetAllAtleta() => base.GetAll();

        public void UpdateAtleta(Atleta atleta) => base.Update(atleta);
    }
}
