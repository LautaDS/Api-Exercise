using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnitOfWork.Models;
using UnitOfWork.UWork;

namespace UnitOfWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculaController : ControllerBase
    {

        private readonly UnitofWork _context;

        public PeliculaController(UnitofWork context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Pelicula>> Get()
        {
            var entidad = _context.PeliculaRepository.GetAll();
            return Ok(entidad);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Pelicula pelicula)
        {
            _context.PeliculaRepository.Add(pelicula);
            _context.Save();
            return Ok();
        }


        [HttpPut("{id}")]
        public ActionResult Put([FromBody] Pelicula pelicula, int id)
        {
            try
            {
                _context.PeliculaRepository.Update(pelicula);
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
            var entity = _context.PeliculaRepository.findId(id);
            if (entity == null)
            {
                return NotFound();
            }
            _context.PeliculaRepository.Delete(entity);
            _context.Save();

            return Ok();
        }
    }
}