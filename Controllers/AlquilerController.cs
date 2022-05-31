using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnitOfWork.Models;
using UnitOfWork.UWork;

namespace UnitOfWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlquilerController : ControllerBase
    {

        private readonly UnitofWork _context;

        public AlquilerController(UnitofWork context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Alquiler>> Get()
        {
            var entidad = _context.AlquilerRepository.GetAll();
            return Ok(entidad);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Alquiler alquiler)
        {
            _context.AlquilerRepository.Add(alquiler);
            _context.Save();
            return Ok();
        }


        [HttpPut("{id}")]
        public ActionResult Put([FromBody] Alquiler alquiler, int id)
        {
            try
            {
                _context.AlquilerRepository.Update(alquiler);
                _context.Save();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var entity = _context.AlquilerRepository.findId(id);
            if (entity == null)
            {
                return NotFound();
            }
            _context.AlquilerRepository.Delete(entity);
            _context.Save();

            return Ok();
        }
    }
}