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
    public class ModalidadeRepository : BaseRepository<Modalidade, int>, IModalidadeRepository
    {
        public ModalidadeRepository() { }

        public ModalidadeRepository(ModalidadeDbContext db)
            : base(db)
        {
        }
        public async Task<Modalidade> GetModalidade(int id) => await Get(id);

        public Modalidade Save(Modalidade modalidade) => Add(modalidade);

        public Task<List<Modalidade>> GetAllModalidades() => base.GetAll();

        public void UpdateModalidade(Modalidade modalidade) => base.Update(modalidade);
    }
}
