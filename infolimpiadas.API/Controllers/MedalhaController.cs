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

    }
}
