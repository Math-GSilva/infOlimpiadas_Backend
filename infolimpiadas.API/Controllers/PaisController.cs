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

    }
}
