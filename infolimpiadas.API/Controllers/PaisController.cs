using infolimpiadas.Domain.Entity;
using infOlimpiadas.Infra;
using Microsoft.AspNetCore.Mvc;

namespace infolimpiadas.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaisController : Controller
    {
        private PaisDbContext _db;

        public PaisController(PaisDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var atletas = _db.Paises.ToList();
            return Ok(atletas);
        }

        [HttpPost]
        public IActionResult Add(Pais pàis)
        {
            var users = _db.Paises.Add(pàis);

            return Ok(users.Entity);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var entity = _db.Paises.FirstOrDefault(e => e.Id == id);
            if (entity != null)
                _db.Paises.Remove(entity);

            return Ok("Removido com sucesso!");
        }

        [HttpPut]
        public IActionResult Update([FromBody] Pais pais)
        {
            var entity = _db.Paises.FirstOrDefault(e => e.Id == pais.Id);
            if (entity != null)
                _db.Entry(entity).CurrentValues.SetValues(pais);

            return Ok(_db.Paises.FirstOrDefault(e => e.Id == pais.Id));
        }

    }
}
