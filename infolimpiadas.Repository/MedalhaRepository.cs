using infolimpiadas.Domain.Entity;
using infolimpiadas.Domain.Repository;
using infOlimpiadas.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infolimpiadas.Repository
{
    public class MedalhaRepository : BaseRepository<Medalha, int>, IMedalhaRepository
    {
        public MedalhaRepository() { }

        public MedalhaRepository(MedalhaDbContext db)
            : base(db)
        {
        }
        public async Task<Medalha> GetMedalha(int id) => await Get(id);

        public Medalha Save(Medalha atleta) => Add(atleta);

        public Task<List<Medalha>> GetAllMedalhas() => base.GetAll();

        public void UpdateMedalha(Medalha atleta) => base.Update(atleta);
    }
}
