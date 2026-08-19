using Microsoft.EntityFrameworkCore;
using MovieApi.Entities;

namespace MovieApi.Data;

public class MovieContext(DbContextOptions<MovieContext> options) : DbContext(options)
{
    public DbSet<Movie> Movies => Set<Movie>();
}
