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

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var entity = _db.Usuarios.FirstOrDefault(e => e.Id == id);
            if (entity != null)
                _db.Usuarios.Remove(entity);

            return Ok("Removido com sucesso!");
        }

        [HttpPut]
        public IActionResult Update([FromBody] Usuario usuario)
        {
            var entity = _db.Usuarios.FirstOrDefault(e => e.Id == usuario.Id);
            if (entity != null)
                _db.Entry(entity).CurrentValues.SetValues(usuario);

            return Ok(_db.Usuarios.FirstOrDefault(e => e.Id == usuario.Id));
        }

    }
}
