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
        public IActionResult Add(Atleta atleta)
        {
            var users = _db.Atletas.Add(atleta);

            return Ok(users.Entity);
        }

    }
}
