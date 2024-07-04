using infolimpiadas.Domain.Entity;
using infolimpiadas.Domain.Service;
using infOlimpiadas.Infra;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace infolimpiadas.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController(IUsuarioService usuarioService, IConfiguration configuration) : Controller
    {
        [HttpPost]
        public IActionResult Add([FromBody]Usuario usuario)
        {
            return Ok(usuarioService.SaveUsuario(usuario));
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestCommand login)
        {
            bool valid = await usuarioService.Login(login);
            if (valid)
            {
                return Ok(GenerateJwtToken(login.Email));
            }

            return Unauthorized();
        }

        [HttpPost]
        [Route("VerificarToken")]
        public IActionResult ValidataToken([FromBody] string token)
        {
            bool valid = ValidateToken(token);
            if (valid)
                return Ok(valid);

            return Unauthorized();
        }

        private string GenerateJwtToken(string username)
        {
            var calims = new[]
            {
                new Claim("user", username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("supersecretkey1asdasdasdasdsdfsdarfgdsfg2345678"));

            var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddMinutes(5);

            JwtSecurityToken token = new JwtSecurityToken(
                claims: calims,
                expires: expiration,
                signingCredentials: credentials
                );

            
            return new JwtSecurityTokenHandler().WriteToken(token); 
        }

        private bool ValidateToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var parameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("supersecretkey1asdasdasdasdsdfsdarfgdsfg2345678")),
            };

            try
            {
                handler.ValidateToken(token, parameters, out SecurityToken validatedToken);
                return true;
            }
            catch (SecurityTokenException)
            {
                return false;
            }
        }
    }
}
