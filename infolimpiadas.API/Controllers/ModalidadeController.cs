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

    }
}
