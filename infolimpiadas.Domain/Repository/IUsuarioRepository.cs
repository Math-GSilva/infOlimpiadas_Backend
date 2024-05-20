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
        public Task<Usuario?> GetUsuario(string user);
        public Usuario Save(Usuario usuario);
        public Task<List<Usuario>> GetAllUsuarios();
        public void UpdateUsuario(Usuario usuario);
    }
}
