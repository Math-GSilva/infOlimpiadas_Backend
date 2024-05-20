using infolimpiadas.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infolimpiadas.Domain.Repository
{
    public interface IModalidadeRepository
    {
        public Task<Modalidade> GetModalidade(int id);
        public Modalidade Save(Modalidade modalidade);
        public Task<List<Modalidade>> GetAllModalidades();
        public void UpdateModalidade(Modalidade modalidade);

    }
}
