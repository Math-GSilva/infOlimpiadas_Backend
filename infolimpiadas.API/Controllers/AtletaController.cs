using infolimpiadas.Domain.Entity;
using infolimpiadas.Domain.Repository;
using infOlimpiadas.Infra;
using Microsoft.AspNetCore.Mvc;

namespace infolimpiadas.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AtletaController : Controller
    {
        private IAtletaRepository atletaRepository;

        public AtletaController(IAtletaRepository atletaRepository)
        {
            this.atletaRepository = atletaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var atletas = await atletaRepository.GetAll();
            return Ok(atletas);
        }

        [HttpPost]
        public IActionResult Add([FromBody]Atleta atleta)
        {
            var objecto = atletaRepository.Save(atleta);

            return Ok(objecto);
        }

        //[HttpDelete]
        //[Route("{id}")]
        //public async Task<IActionResult> DeleteAsync(int id)
        //{
        //    var list = await atletaRepository.GetAll();
        //    var entity = list.FirstOrDefault(e => e.Id == id);
        //    if(entity != null)
        //        atletaRepository.Remove(entity);

        //    _db.SaveChanges();
        //    return Ok("Removido com sucesso!");
        //}

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Atleta atleta)
        {
            var entity = await atletaRepository.GetAtleta(atleta.Id);
            if (entity != null)
                atletaRepository.Update(entity);

            return Ok();
        }
    }
}
