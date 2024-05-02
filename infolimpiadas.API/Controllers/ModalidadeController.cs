using infolimpiadas.Domain.Entity;
using infOlimpiadas.Infra;
using Microsoft.AspNetCore.Mvc;

namespace infolimpiadas.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ModalidadeController : Controller
    {
        private ModalidadeDbContext _db;

        public ModalidadeController(ModalidadeDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var atletas = _db.Modalidades.ToList();
            return Ok(atletas);
        }

        [HttpPost]
        public IActionResult Add(Modalidade modalidade)
        {
            var users = _db.Modalidades.Add(modalidade);

            return Ok(users.Entity);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var entity = _db.Modalidades.FirstOrDefault(e => e.Id == id);
            if (entity != null)
                _db.Modalidades.Remove(entity);

            return Ok("Removido com sucesso!");
        }

        [HttpPut]
        public IActionResult Update([FromBody] Modalidade modalidade)
        {
            var entity = _db.Modalidades.FirstOrDefault(e => e.Id == modalidade.Id);
            if (entity != null)
                _db.Entry(entity).CurrentValues.SetValues(modalidade);

            return Ok(_db.Modalidades.FirstOrDefault(e => e.Id == modalidade.Id));
        }

    }
}
