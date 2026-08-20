using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApi.Data;
using MovieApi.Dtos;
using MovieApi.Entities;

namespace MovieApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MoviesController(MovieContext context) : ControllerBase
{
    // endpoints

    //  GET
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MovieDto>>> GetMovies()
    {
        var movies = await context.Movies.ToListAsync();

        var dtos = movies.Select(m => new MovieDto(
                    m.Id,
                    m.Title,
                    m.Genre,
                    m.Director,
                    m.ReleaseYear,
                    m.DurationMinutes,
                    m.Rating,
                    m.Description
                    )
                );

        return Ok(dtos);
    }

    // GET id

    // POST
}
