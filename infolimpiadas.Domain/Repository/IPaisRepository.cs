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
        public Task<Pais> GetPais(int id);
        public Pais Save(Pais pais);
        public Task<List<Pais>> GetAllPaiss();
        public void UpdatePais(Pais pais);
    }
}
