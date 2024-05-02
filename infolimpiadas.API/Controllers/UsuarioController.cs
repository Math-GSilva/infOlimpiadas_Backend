using infolimpiadas.Domain.Entity;
using infOlimpiadas.Infra;
using Microsoft.AspNetCore.Mvc;

namespace infolimpiadas.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : Controller
    {
        private UsuarioDbContext _db;

        public UsuarioController(UsuarioDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var atletas = _db.Usuarios.ToList();
            return Ok(atletas);
        }

        [HttpPost]
        public IActionResult Add(Usuario usuario)
        {
            var users = _db.Usuarios.Add(usuario);

            return Ok(users.Entity);
        }

    }
}
