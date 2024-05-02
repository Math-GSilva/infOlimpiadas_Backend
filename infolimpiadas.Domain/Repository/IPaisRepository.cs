using infolimpiadas.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infolimpiadas.Domain.Repository
{
    public interface IPaisRepository
    {
        public Pais GetPais(int id);
        public IEnumerable<Pais> GetAll();
        public IEnumerable<Pais> GetAllForCountry();
        public Pais Save(Pais pais);
        public Pais Update(Pais pais);
        public void Delete(int id);
    }
}
