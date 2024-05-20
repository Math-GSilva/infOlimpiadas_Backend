using infolimpiadas.Domain.Entity;
using infolimpiadas.Domain.Service;
using infOlimpiadas.Infra;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace infolimpiadas.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : Controller
    {
        private IUsuarioService usuarioService;
        private IConfiguration configuration;

        public UsuarioController(IUsuarioService usuarioService, IConfiguration configuration)
        {
            this.usuarioService = usuarioService;
            this.configuration = configuration;
        }

        [HttpPost]
        public IActionResult Add([FromBody]Usuario usuario)
        {
            return Ok(usuarioService.SaveUsuario(usuario));
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] Usuario usuario)
        {
            bool valid = await usuarioService.Login(usuario);
            if (valid)
            {
                return Ok(GenerateJwtToken(usuario.Email));
            }

            return Unauthorized();
        }

        private string GenerateJwtToken(string username)
        {
            var calims = new[]
            {
                new Claim("user", username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));

            var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddMinutes(5);

            JwtSecurityToken token = new JwtSecurityToken(
                claims: calims,
                expires: expiration,
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token); 
        }
    }
}
