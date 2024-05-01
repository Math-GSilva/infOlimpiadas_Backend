using infolimpiadas.Domain.Entity;

namespace infolimpiadas.Domain.Repository
{
    public interface IAtletaRepository
    {
        public Atleta GetAtleta(int id);
        public IEnumerable<Atleta> GetAll();
        public IEnumerable<Atleta> GetAllForCountry();
        public Atleta Save(Atleta atleta);
        public Atleta Update(Atleta atleta);
        public void Delete(int id);
    }
}
