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
    public class UsuarioRepository : BaseRepository<Usuario, int>, IUsuarioRepository
    {
        public UsuarioRepository() { }

        public UsuarioRepository(UsuarioDbContext db)
            : base(db)
        {
        }
        public async Task<Usuario?> GetUsuario(string user)
        {
            var results = await base.GetAll();
            return results.Find(usuario => usuario.Email.Equals(user, StringComparison.Ordinal));
        }

        public Usuario Save(Usuario usuario) => Add(usuario);

        public Task<List<Usuario>> GetAllUsuarios() => base.GetAll();

        public void UpdateUsuario(Usuario usuario) => base.Update(usuario);
    }
}
