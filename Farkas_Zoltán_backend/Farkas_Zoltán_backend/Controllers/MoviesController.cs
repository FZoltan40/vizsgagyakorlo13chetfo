using Farkas_Zoltán_backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Farkas_Zoltán_backend.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly CinemdbContext _context;

        public MoviesController(CinemdbContext context)
        {
            _context = context;
        }

        [HttpGet("feladat10")]
        public async Task<ActionResult<Movie>> Get()
        {
            var movies = await _context.Movies.ToListAsync();

            if (movies != null)
            {
                return Ok(movies);
            }

            Exception e = new();
            return BadRequest(new { message = e.Message });

        }

        [HttpPost("feladat13")]
        public async Task<ActionResult> AddNewMovie(string id, Movie movie)
        {
            var builder = WebApplication.CreateBuilder();
            string uid = builder.Configuration.GetValue<string>("Code");

            if (uid != null && uid == id)
            {
                var mov = new Movie
                {
                    Title = movie.Title,
                    ReleaseDate = movie.ReleaseDate,
                    ActorId = movie.ActorId,
                    FilmTypeId = movie.FilmTypeId
                };

                if (mov != null)
                {
                    await _context.Movies.AddAsync(mov);
                    await _context.SaveChangesAsync();
                    return StatusCode(201, "Film hozzáadása sikeresen megtörtént.");
                }

                return BadRequest();

            }

            return StatusCode(401, "Nincs jogosultsága új film felviteléhez.");

        }
    }
}
