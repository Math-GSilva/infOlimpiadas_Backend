using infolimpiadas.Domain.Entity;
using infOlimpiadas.Infra;
using Microsoft.AspNetCore.Mvc;

namespace infolimpiadas.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AtletaController : Controller
    {
        private AtletaDbContext _db;

        public AtletaController(AtletaDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var atletas = _db.Atletas.ToList();
            return Ok(atletas);
        }

        [HttpPost]
        public IActionResult Add([FromBody]Atleta atleta)
        {
            var users = _db.Atletas.Add(atleta);

            _db.SaveChanges();

            return Ok(users.Entity);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var entity = _db.Atletas.FirstOrDefault(e => e.Id == id);
            if(entity != null)
                _db.Atletas.Remove(entity);

            _db.SaveChanges();
            return Ok("Removido com sucesso!");
        }

        [HttpPut]
        public IActionResult Update([FromBody] Atleta atleta)
        {
            var entity = _db.Atletas.FirstOrDefault(e => e.Id == atleta.Id);
            if (entity != null)
                _db.Entry(entity).CurrentValues.SetValues(atleta);

            _db.SaveChanges();

            return Ok(_db.Atletas.FirstOrDefault(e => e.Id == atleta.Id));
        }
    }
}
