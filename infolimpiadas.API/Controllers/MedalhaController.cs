using infolimpiadas.Domain.Entity;
using infolimpiadas.Domain.Repository;
using infOlimpiadas.Infra;
using Microsoft.AspNetCore.Mvc;

namespace infolimpiadas.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedalhaController : Controller
    {
        private IMedalhaRepository medalhaRepository;

        public MedalhaController(IMedalhaRepository medalhaRepository)
        {
            this.medalhaRepository = medalhaRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var atletas = medalhaRepository.GetAllMedalhas();
            return Ok(atletas);
        }

        [HttpPost]
        public IActionResult Add(Medalha medalha)
        {
            var medalhaObj = medalhaRepository.Save(medalha);

            return Ok(medalhaObj);
        }

        //[HttpDelete]
        //[Route("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    var entity = _db.Medalhas.FirstOrDefault(e => e.Id == id);
        //    if (entity != null)
        //        _db.Medalhas.Remove(entity);

        //    _db.SaveChanges();

        //    return Ok("Removido com sucesso!");
        //}

        [HttpPut]
        public IActionResult Update([FromBody] Medalha medalha)
        {
            var entity = medalhaRepository.GetMedalha(medalha.Id);
            if (entity != null)
                medalhaRepository.Save(medalha);

            return Ok();
        }
    }
}
