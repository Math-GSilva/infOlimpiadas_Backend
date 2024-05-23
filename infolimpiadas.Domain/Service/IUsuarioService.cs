using infolimpiadas.Domain.Entity;

namespace infolimpiadas.Domain.Service
{
    public interface IUsuarioService
    {
        public Usuario SaveUsuario(Usuario usuario);
        public Task<bool> Login (LoginRequestCommand login);
    }
}
