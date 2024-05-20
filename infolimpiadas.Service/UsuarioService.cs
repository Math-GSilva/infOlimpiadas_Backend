using infolimpiadas.Domain.Entity;
using infolimpiadas.Domain.Repository;
using infolimpiadas.Domain.Service;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace infolimpiadas.Service
{
    public class UsuarioService : IUsuarioService
    {
        IUsuarioRepository usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }

        public async Task<bool> Login(Usuario usuario)
        {
            var user = await usuarioRepository.GetUsuario(usuario.Email);
            if(user == null)
            {
                return false;
            }
            else
            {
                var senhaDigitada = BCrypt.Net.BCrypt.HashPassword(usuario.Password);
                if(senhaDigitada == user.Password)
                {
                    return true;
                }
            }
            return false;
        }

        public Usuario SaveUsuario(Usuario usuario)
        {
            usuario.Password = BCrypt.Net.BCrypt.HashPassword(usuario.Password);
            return this.usuarioRepository.Save(usuario);
        }
    }
}
