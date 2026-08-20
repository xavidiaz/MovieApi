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
    public async Task<ActionResult<IEnumerable<MovieDto>>> GetMovies(string? genre = null)
    {
        var query = context.Movies.AsQueryable();

        if (!string.IsNullOrWhiteSpace(genre))
        {
            query = query.Where(m => m.Genre.ToLower() == genre.ToLower());
        }

        var movies = await query.ToListAsync();

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
    [HttpGet("{id:int}")]
    public async Task<ActionResult<MovieDto>> GetMovieById(int id)
    {
        var movie = await context.Movies.FindAsync(id);
        if (movie is null) return NotFound();

        var dto = new MovieDto(
                movie.Id, movie.Title, movie.Genre, movie.Director, movie.ReleaseYear, movie.DurationMinutes, movie.Rating, movie.Description
                );

        return Ok(dto);
    }

    // POST
    [HttpPost]
    public async Task<ActionResult<MovieDto>> CreateMovie(CreateMovieDto input)
    {
        var movie = new Movie
        {
            Title = input.Title,
            Genre = input.Genre,
            Director = input.Director,
            ReleaseYear = input.ReleaseYear,
            DurationMinutes = input.DurationMinutes,
            Rating = input.Rating,
            Description = input.Description
        };

        context.Movies.Add(movie);
        await context.SaveChangesAsync();

        var dto = new MovieDto(
                movie.Id, movie.Title, movie.Genre, movie.Director, movie.ReleaseYear, movie.DurationMinutes, movie.Rating, movie.Description
                );

        return CreatedAtAction(
                nameof(GetMovieById),
                new { id = movie.Id },
        dto
                );

    }
}
