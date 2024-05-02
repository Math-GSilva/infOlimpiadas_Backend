using infolimpiadas.Domain.Entity;
using infOlimpiadas.Infra;
using Microsoft.AspNetCore.Mvc;

namespace infolimpiadas.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedalhaController : Controller
    {
        private MedalhaDbContext _db;

        public MedalhaController(MedalhaDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var atletas = _db.Medalhas.ToList();
            return Ok(atletas);
        }

        [HttpPost]
        public IActionResult Add(Medalha medalha)
        {
            var users = _db.Medalhas.Add(medalha);

            return Ok(users.Entity);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var entity = _db.Medalhas.FirstOrDefault(e => e.Id == id);
            if (entity != null)
                _db.Medalhas.Remove(entity);

            return Ok("Removido com sucesso!");
        }

        [HttpPut]
        public IActionResult Update([FromBody] Medalha medalha)
        {
            var entity = _db.Medalhas.FirstOrDefault(e => e.Id == medalha.Id);
            if (entity != null)
                _db.Entry(entity).CurrentValues.SetValues(medalha);

            return Ok(_db.Medalhas.FirstOrDefault(e => e.Id == medalha.Id));
        }
    }
}
