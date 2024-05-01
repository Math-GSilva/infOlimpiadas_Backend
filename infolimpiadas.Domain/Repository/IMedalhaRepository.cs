using infolimpiadas.Domain.Entity;

namespace infolimpiadas.Domain.Repository
{
    public interface IMedalhaRepository
    {
        public Medalha GetMedalha(int id);
        public IEnumerable<Medalha> GetAll();
        public IEnumerable<Medalha> GetAllForCountry();
        public Medalha Save(Medalha atleta);
        public Medalha Update(Medalha atleta);
        public void Delete(int id);
    }
}
