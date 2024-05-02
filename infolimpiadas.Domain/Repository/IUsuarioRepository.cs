using infolimpiadas.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infolimpiadas.Domain.Repository
{
    public interface IUsuarioRepository
    {
        public Usuario GetUsuario(int id);
        public IEnumerable<Usuario> GetAll();
        public IEnumerable<Usuario> GetAllForCountry();
        public Usuario Save(Usuario usuario);
        public Usuario Update(Usuario usuario);
        public void Delete(int id);
    }
}
