using Farkas_Zoltán_backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Farkas_Zoltán_backend.Controllers
{
    [Route("api/filmtypes")]
    [ApiController]
    public class FilmtypesController : ControllerBase
    {
        private readonly CinemdbContext _context;

        public FilmtypesController(CinemdbContext context)
        {
            _context = context;
        }

        [HttpGet("feladat11")]
        public async Task<ActionResult<FilmType>> Get()
        {
            var filmtypes = await _context.FilmTypes.Include(flm => flm.Movies).ToListAsync();

            if (filmtypes != null)
            {
                return Ok(filmtypes);
            }

            Exception e = new();
            return BadRequest(new { message = e.Message });
        }
    }
}
