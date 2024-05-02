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
        public Modalidade GetModalidade(int id);
        public IEnumerable<Modalidade> GetAll();
        public IEnumerable<Modalidade> GetAllForCountry();
        public Modalidade Save(Modalidade modalidade);
        public Modalidade Update(Modalidade modalidade);
        public void Delete(int id);
    }
}
