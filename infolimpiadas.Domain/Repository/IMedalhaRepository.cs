using infolimpiadas.Domain.Entity;

namespace infolimpiadas.Domain.Repository
{
    public interface IMedalhaRepository
    {
        public Task<Medalha> GetMedalha(int id);
        public Medalha Save(Medalha atleta);
        public Task<List<Medalha>> GetAllMedalhas();
        public void UpdateMedalha(Medalha atleta);

    }
}
