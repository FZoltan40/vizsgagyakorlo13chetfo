using Farkas_Zoltán_backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Farkas_Zoltán_backend.Controllers
{
    [Route("api/actors")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly CinemdbContext _context;

        public ActorsController(CinemdbContext context)
        {
            _context = context;
        }

        [HttpGet("feladat9")]
        public async Task<ActionResult<Actor>> Get(string name)
        {
            var actor = await _context.Actors.Include(act => act.Movies).FirstOrDefaultAsync(act => act.ActorName == name);

            if (actor != null)
            {
                return Ok(actor);
            }

            return NotFound();
        }

        [HttpGet("feladat12")]
        public async Task<ActionResult<string>> NumOfActors()
        {
            var num = await _context.Actors.CountAsync();

            if (num > -1)
            {
                return Ok($"Színézek száma: {num}");
            }

            return BadRequest("Nem lehet csatlakozni az adatbázishoz.");

        }
    }
}
