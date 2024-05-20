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
    public class PaisRepository : BaseRepository<Pais, int>, IPaisRepository
    {
        public PaisRepository() { }

        public PaisRepository(PaisDbContext db)
            : base(db)
        {
        }
        public async Task<Pais> GetPais(int id) => await Get(id);

        public Pais Save(Pais pais) => Add(pais);

        public Task<List<Pais>> GetAllPaiss() => base.GetAll();

        public void UpdatePais(Pais pais) => base.Update(pais);
    }
}
